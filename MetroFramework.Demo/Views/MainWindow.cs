﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Collections.Concurrent;
using Emgu.CV;
using Emgu.CV.Structure;
using Nkujukira.Entities;
using System.Diagnostics;
using Emgu.CV.UI;
using MB.Controls;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Singletons;
using Nkujukira.Demo.Factories;
using Nkujukira.Demo.Views;
using Nkujukira.Demo.Threads;
using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Interfaces;
using MetroFramework.Controls;
using System.Threading;
using MetroFramework;

namespace Nkujukira.Demo
{
    public partial class MainWindow : MetroForm
    {
        private const string SELECT_VIDEO_MESSAGE        = "Please Select a Video file";
        private const string LOAD_CAMERA_FOOTAGE_MESSAGE = "You Are Loading Footage From Your camera!!";
        private const string FILE_FILTER                 = "All files (*.*)|*.*";
        private const string MESSAGE_BOX_TITLE           = "Message!!";
        private const string PAUSE_BUTTON_TEXT           = "Pause";
        private const string PLAY_BUTTON_TEXT            = "Play";
        private bool cctv_cameras_are_on                 = false;


        public MainWindow()
        {
            InitializeComponent();

            //AM THINKING I WILL NEED TO KEEP A REFERENCE OF THIS SO I CAN ACCESS THE SAME INSTANCE OF THE MAINWINDOW
            //IN OTHER FORMS AND VIEWS
            Singleton.MAIN_WINDOW = this;

            DisableControls();
        }

        //THIS DISPLAYS A DIALOG ALLOWING A USER TO LOAD A VIDEO
        //IT THEN STARTS THREADS TO LOAD AND PROCESS VIDEO FRAME BY FRAME
        private void pick_video_button_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadFactory.StopReviewFootageThreads();
                Singleton.ClearReviewFootageDataStores();
                ThreadFactory.ReleaseAllThreadResources();

                VideoFile vid = PickVideoFileToPlay();

                if (vid != null)
                {
                    StartReviewFootageThreads(vid);
                    EnableControls();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //PAUSES THE RUNNING VIDEO UPON CALL
        private void pause_button_Click(object sender, EventArgs e)
        {
            if (pause_button.Text == PAUSE_BUTTON_TEXT)
            {
                PauseVideo();
            }
            else
            {
                ResumeVideo();
            }
        }

        //STOPS RUNNING VIDEO UPON CALL [CLICK OF STOP BUTTON]
        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                //STOP ALL RUNNING THREADS
                ThreadFactory.StopReviewFootageThreads();

                //CLEARS DATASTORES
                Singleton.ClearReviewFootageDataStores();

                //RELEASES ALL RESOURCES BEING HELD BY THREADS
                ThreadFactory.ReleaseAllThreadResources();

                //CLEAR FACE_COMPARISON_PANEL
                ClearPanel(panel_for_detected_faces);
            }
            catch (Exception)
            {


            }
        }



        private void ClearPanel(Panel panel)
        {
            //CREATE TITLE LABEL
            MetroLabel title_label = new MetroLabel();
            title_label.Theme = MetroThemeStyle.Dark;
            title_label.ForeColor = Color.White;
            title_label.AutoSize = true;
            title_label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title_label.Location = new System.Drawing.Point(74, 11);
            title_label.Size = new System.Drawing.Size(205, 19);
            title_label.TabIndex = 3;
            title_label.Text = "FACE COMPARISON ONGOING";

            //CREATE LINE SEPARATOR 
            MetroLabel separator_label = new MetroLabel();
            separator_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            separator_label.Location = new System.Drawing.Point(19, 39);
            separator_label.Size = new System.Drawing.Size(335, 2);
            separator_label.TabIndex = 2;

            //COZ THIS IS NOT ON THE UI THREAD
            if (panel.InvokeRequired)
            {
                //CLEAR THE PANEL
                Action action = () => panel.Controls.Clear();
                panel.Invoke(action);

                //ADD TITLE AND SEPARATOR LINE TO PANEL
                action = () => panel.Controls.AddRange(new Control[] { title_label, separator_label });
                panel.Invoke(action);
            }

            //IF ON UI THREAD::HIGHLY UNLIKELY
            else
            {
                //CLEAR THE PANEL
                panel.Controls.Clear();

                //ADD TITLE AND SEPARATOR LINE TO PANEL
                panel.Controls.AddRange(new Control[] { title_label, separator_label });
            }


        }

        //THIS HANDLES THE REVIEW FOOTAGE IMAGE BOX SLIDER SCROLL EVENT
        private void SlidersScroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (!ReviewDisplayUpdater.WORK_DONE)
                {
                    //GET VALUE USER HAS SCROLLED TO
                    int value = (sender as ColorSlider).Value;

                    //GET THE PERCENTAGE REPRESENTING THAT VALUE
                    double ratio = ((((double)value) / ((double)100)));

                    //FORWARD TO THAT PART OF THE VIDEO
                    GoToThatPartOfTheVideo(ratio);

                }

                //ELSE THE DISPLAY UPDATER IS DONE DISPLAYING VIDEO SO
                else
                {
                    //DISABLE SLIDER
                    slider_review_footage.Value = 0;
                    slider_review_footage.Enabled = false;
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

        }



        //STARTS ALL NECESSARY THREADS
        private void StartReviewFootageThreads(VideoFile video)
        {
            Singleton.CURRENT_VIDEO_FILE = video;
            ThreadFactory.StartReviewFootageThreads();
        }

        //STARTS ALL NECESSARY THREADS
        private void StartLiveStreamThreads()
        {
            PickCameraForm form = new PickCameraForm();
            form.ShowDialog();

            if (form.selected_camera != null)
            {
                ThreadFactory.StartLiveStreamThreads(form.selected_camera);
            }
           
        }

        //ATTEMPTS TO PAUSE A RUNNING VIDEO
        public void PauseVideo()
        {
            ThreadFactory.PauseAllThreads();
            AbstractThread.SetControlPropertyThreadSafe(pause_button, "Text", PLAY_BUTTON_TEXT);
        }

        //ATTEMPTS TO RESUME A PREVIOUSLY PAUSED VIDEO
        public void ResumeVideo()
        {
            ThreadFactory.ResumeAllThreads();
            AbstractThread.SetControlPropertyThreadSafe(pause_button, "Text", PAUSE_BUTTON_TEXT);

        }

        //ENABLES DRAWING OF DETECTED FACES ON TO THE FRAMES
        private void show_detected_faces2_CheckedChanged(object sender, EventArgs e)
        {
            ReviewFaceDetectingThread.draw_detected_faces = !ReviewFaceDetectingThread.draw_detected_faces;
        }

        //FORWARDS TO A CERTAIN PART OF A VIDEO
        private void GoToThatPartOfTheVideo(double ratio)
        {
            //IF THERE IS A PLAYING VIDEO
            if (Singleton.CURRENT_VIDEO_FILE != null)
            {
                //PAUSE THE VIDEO
                ThreadFactory.PauseAllThreads();

                //CLEAR ALL THE DATA STORES 
                Singleton.ClearReviewFootageDataStores();

                //GET THE MILLESCONDS GO FORWARD TO
                double millescond_to_jump_to = ratio * Singleton.CURRENT_VIDEO_FILE.video_length_in_millisecs;

                //FORWARD THE VIDEO
                ((VideoFromFileThread)ThreadFactory.GetThread(ThreadFactory.VIDEO_THREAD)).RewindOrForwardVideo(millescond_to_jump_to);

                //SET THE TIME ELAPSED ON THE VIDEO
                ((ReviewDisplayUpdater)ThreadFactory.GetThread(ThreadFactory.REVIEW_DISPLAY_UPDATER)).SetTimeElapsed(millescond_to_jump_to);

                //RESUME PLAYING THE VIDEO
                ThreadFactory.ResumeAllThreads();
            }
        }


        //THIS RETURNS A FILEPATH TO A GIVEN VIDEO 
        //AFTER PRESENTING A USER WITH A DIALOG
        private VideoFile PickVideoFileToPlay()
        {
            String file_name = null;
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = FILE_FILTER;
                dialog.Title = SELECT_VIDEO_MESSAGE;
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    file_name = dialog.FileName;

                    if (file_name != null)
                    {
                        return new VideoFile(1, file_name);
                    }
                    else
                    {
                        MessageBox.Show(this, SELECT_VIDEO_MESSAGE, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return PickVideoFileToPlay();
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        //INITIALIZES ALL DATA STORES AND NECESSARY OBJECTS
        public void InitializeStuff()
        {

            //show_detected_faces2.Checked       = false;
        }

        //THIS DISABLES UNECESSARY CONTROLS
        public void DisableControls()
        {
            if (pause_button != null)
            {
                pause_button.Enabled = false;
            }
            if (stop_button_2 != null)
            {
                stop_button_2.Enabled = false;
            }
            if (slider_review_footage != null)
            {
                slider_review_footage.Enabled = false;
            }
            ResetButtonText();

            //ENABLE THE PICK VIDEO BUTTON
            //SO THE USER HAS THE ABILITY TO PICK 
            //ANOTHER VIDEO
            pick_video_button.Enabled = true;

        }

        //THIS ENABLES THE NECESSARY CONTROLS
        public void EnableControls()
        {

            if (pause_button != null)
            {
                pause_button.Enabled = true;
            }
            if (stop_button_2 != null)
            {
                stop_button_2.Enabled = true;
            }
            if (slider_review_footage != null)
            {
                slider_review_footage.Enabled = true;
            }
            ResetButtonText();

            //DISABLE THE PICK VIDEO BUTTON
            //SO THE USER CAN NOT PICK ANOTHER VIDEO
            //WHILE THE CURRENT ONE IS STILL RUNNING
            pick_video_button.Enabled = true;
        }

        //RESETS NECESSARY BUTTON TEXTS TO DEFAULTS
        private void ResetButtonText()
        {
            pause_button.Text = "Pause";
        }

        //RETURNS THE REVIEW FOOTAGE IMAGE BOX
        public ImageBox GetReviewFootageImageBox()
        {
            return this.review_footage_image_box;
        }

        //  RETURNS THE COLOR SLIDER
        public ColorSlider GetColorSlider()
        {
            return review_footage_color_slider;
        }

        //returns a given control on this form provided its name
        public Control GetControl(MainWindowControls name)
        {
            switch (name)
            {
                case MainWindowControls.time_elapsed:
                    return time_elapsed_label;

                case MainWindowControls.total_time:
                    return total_time_label;

                case MainWindowControls.review_image_box:
                    return review_footage_image_box;

                case MainWindowControls.live_stream_image_box1:
                    return imageBox1;

                case MainWindowControls.live_stream_image_box2:
                    return imageBox2;

                case MainWindowControls.live_stream_image_box3:
                    return imageBox3;

                case MainWindowControls.live_stream_image_box4:
                    return imageBox4;

                case MainWindowControls.review_footage_panel:
                    return panel_for_detected_faces;

                case MainWindowControls.live_stream_panel:
                    return live_stream_recognition_panel;

                case MainWindowControls.spining_progress_review:
                    return spining_progress_review;

            }
            return null;
        }

        public enum MainWindowControls 
        {
            time_elapsed,
            total_time,
            review_footage_panel,
            review_image_box,
            live_stream_image_box1,
            live_stream_image_box2,
            live_stream_image_box3,
            live_stream_image_box4,
            live_stream_panel,
            spining_progress_review,
        }


        //HANDLES A CLICK EVENT IN THE REVIEW FOOTAGE BOX
        private void review_footage_image_box_Click(object sender, EventArgs e)
        {
            if ((ThreadFactory.GetThread(ThreadFactory.REVIEW_DISPLAY_UPDATER) as ReviewDisplayUpdater) != null)
            {
                if (review_footage_image_box.Image != null)
                {
                    //pause the video
                    PauseVideo();

                    //create new form
                    SelectPerpetratorForm form = new SelectPerpetratorForm((Image<Bgr, byte>)review_footage_image_box.Image);
                    form.ShowDialog();
                }
            }
        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog();
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            ChangeUserTypeDialog dialog = new ChangeUserTypeDialog();
            dialog.ShowDialog();

        }


        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            StudentDetailsForm dialog = new StudentDetailsForm();
            dialog.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            spining_progress_review.Start();
            spining_progress_live.Start();
            spining_progress_review.Visible = false;
            spining_progress_live.Visible = false;
            if (Singleton.ADMIN != null)
            {
                linkLabel_logout.Text = Singleton.ADMIN.user_name + ": Log out";
                return;
            }
            linkLabel_logout.Visible = false;

        }

        void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear the detected faces panel when the user switches tabs
            if (panel_for_detected_faces != null)
            {
                panel_for_detected_faces.Controls.Clear();
                panel_for_detected_faces.Controls.Add(label_face_recognition_status);
                panel_for_detected_faces.Controls.Add(label_separator);
            }
        }

        // show add new user dialog on clicking addnew user dialog
        private void tile1_Click(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog();
        }

        // show dialog when add student tile is clicked
        private void AddStudent_Tile_Click(object sender, EventArgs e)
        {
            StudentDetailsForm dialog = new StudentDetailsForm();
            dialog.ShowDialog();
        }

        // show dialog when change user role tile is clicked
        private void ChangeUserRole_Tile_Click(object sender, EventArgs e)
        {
            ChangeUserTypeDialog dialog = new ChangeUserTypeDialog();
            dialog.ShowDialog();
        }

        // show change login credentials dialog on clicking the change login credentials tile 
        private void ChangeLogin_Tile_Click(object sender, EventArgs e)
        {
            ChangeUserLoginDetailsForm form = new ChangeUserLoginDetailsForm();
            form.ShowDialog();
        }

        private void DashBoard_Tile_Click(object sender, EventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();

        }

       
        private void turn_on_button_Click(object sender, EventArgs e)
        {
            turn_on_button.Enabled       = false;
            use_video_button.Enabled     = false;

            if (!cctv_cameras_are_on)
            {
                TurnOnCameras(null);
                cctv_cameras_are_on      = true;
                turn_on_button.Text      = "Turn Off";
                turn_on_button.Enabled   = true;
            }
            else
            {
                TurnOffCameras(null);
                cctv_cameras_are_on      = false;
                turn_on_button.Text      = "Use Camera";
                turn_on_button.Enabled   = true;
                use_video_button.Enabled = true;
            }
        }

        private void TurnOnCameras(object state)
        {
            //DisableLiveStreamControls();

            ThreadFactory.StopLiveStreamThreads();
            Singleton.ClearLiveStreamDataStores();
            //ThreadFactory.ReleaseLiveStreamThreadsResources();
            StartLiveStreamThreads();
            //ChangeButtonText();

            //EnableLiveStreamControls();
        }

        private void TurnOffCameras(object state)
        {
            //DisableLiveStreamControls();

            ThreadFactory.StopLiveStreamThreads();
            Singleton.ClearLiveStreamDataStores();
            ClearPanel(live_stream_recognition_panel);
            //ThreadFactory.ReleaseLiveStreamThreadsResources();
            //ChangeButtonText();

            //EnableLiveStreamControls();
        }

        private void TurnOnCamerasUsingVideo(object state)
        {
            //DisableLiveStreamControls();
            ThreadFactory.StopLiveStreamThreads();        
            Singleton.ClearLiveStreamDataStores();
            //ThreadFactory.ReleaseLiveStreamThreadsResources();
            ThreadFactory.StartLiveStreamThreadsUsingVideo();
            //ChangeButtonText();
            //EnableLiveStreamControls();
        }


        private void TurnOffCamerasUisngVideo(object state)
        {
            //DisableLiveStreamControls();
            ThreadFactory.StopLiveStreamThreads();
            Singleton.ClearLiveStreamDataStores();
            ClearPanel(live_stream_recognition_panel);
            //ThreadFactory.ReleaseLiveStreamThreadsResources();
            //ChangeButtonText();
            //EnableLiveStreamControls();
        }

        private void EnableLiveStreamControls()
        {
            Action action;
            action = () => turn_on_button.Enabled = true;
            turn_on_button.Invoke(action);
            action = () => use_video_button.Enabled = true;
            use_video_button.Invoke(action);
            action = () => spining_progress_live.Visible = false;
            spining_progress_live.Invoke(action);
            return;
        }

        public void DisableLiveStreamControls()
        {
            Action action = () => turn_on_button.Enabled = false;
            turn_on_button.Invoke(action);
            action = () => use_video_button.Enabled = false;
            use_video_button.Invoke(action);
            action = () => spining_progress_live.Visible = true;
            spining_progress_live.Invoke(action);
        }

        private void ChangeButtonText()
        {
            Action action;
            if (!cctv_cameras_are_on)
            {
                action = () => turn_on_button.Text = "Use Camera";
                turn_on_button.Invoke(action);
                action = () => use_video_button.Text = "Use Video";
                use_video_button.Invoke(action);
            }
            else
            {
                action = () => turn_on_button.Text = "Turn Off";
                turn_on_button.Invoke(action);
                action = () => use_video_button.Text = "Turn Off";
                use_video_button.Invoke(action);
            }
        }

        private void AddNewUser_Tile_Cliick(object sender, EventArgs e)
        {
            AddNewUserForm form = new AddNewUserForm();
            form.ShowDialog();
        }

        private void MostWantedTile_Click(object sender, EventArgs e)
        {
            PerpetratorsListDialog form = new PerpetratorsListDialog();
            form.ShowDialog();
        }

        private void LogoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Singleton.ADMIN = null;
            Program.Running = true;
            this.Close();

        }

        public void EnableReviewControls()
        {
            if (spining_progress_review.InvokeRequired)
            {
                Action action = () => spining_progress_review.Visible = false;
                spining_progress_review.Invoke(action);
                action = () => pick_video_button.Enabled = true;
                pick_video_button.Invoke(action);
                action = () => pause_button.Enabled = true;
                pause_button.Invoke(action);
            }
            else
            {
                spining_progress_review.Visible = false;
                spining_progress_review.Enabled = false;
                pick_video_button.Enabled = true;
                pause_button.Enabled = true;
            }

        }

        public void DisableReviewControls()
        {
            if (spining_progress_review.InvokeRequired)
            {
                Action action = () => spining_progress_review.Enabled = true;
                spining_progress_review.Invoke(action);
                action = () => pick_video_button.Enabled = false;
                pick_video_button.Invoke(action);
                action = () => pause_button.Enabled = false;
                pause_button.Invoke(action);
            }
            else
            {
                spining_progress_review.Visible = true;
                spining_progress_review.Enabled = true;
                pick_video_button.Enabled = false;
                pause_button.Enabled = false;
            }
        }

        private void imageBox4_Click(object sender, EventArgs e)
        {

            CCTVDetailsForm cctv_display_form = new CCTVDetailsForm(new Camera());
            cctv_display_form.ShowDialog();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ThreadFactory.StopAllThreads();
            Program.Running = false;
        }


        private void ButtonUseVideo_Click(object sender, EventArgs e)
        {
            if (!cctv_cameras_are_on)
            {
                use_video_button.Enabled          = false;
                turn_on_button.Enabled            = false;
                Singleton.CURRENT_VIDEO_FILE      = PickVideoFileToPlay();

                if (Singleton.CURRENT_VIDEO_FILE != null)
                {
                    TurnOnCamerasUsingVideo(null);
                    cctv_cameras_are_on           = true;
                    use_video_button.Text         = "Turn Off";
                    use_video_button.Enabled      = true;
                    return;
                }

                use_video_button.Enabled          = true;
                turn_on_button.Enabled            = true;
                
            }
            else
            {
                use_video_button.Enabled          = false;
                TurnOffCamerasUisngVideo(null);
                cctv_cameras_are_on               = false;
                turn_on_button.Enabled            = true;
                use_video_button.Text             = "Use Video";
                use_video_button.Enabled          = true;
            }
        }

        private void button_camera_enroll_Click(object sender, EventArgs e)
        {
            button_camera_enroll.Enabled = false;
            ThreadFactory.StopReviewFootageThreads();
            Singleton.ClearReviewFootageDataStores();
            ThreadFactory.ReleaseAllThreadResources();

            //WHEN THIS BUTTON IS CLICKED 
            //A CONFIRMATION MESSAGE BOX POPS UP
            //ON CONFIRMATION A CHECK IS MADE TO ENSURE THAT THE SYSTEM HAS ATLEAST A CAMERA CONNECTED
            //NECESSARY THREADS ARE SPAWNED
            //AND THE FRAMES ARE GRABBED FROM THE CONNECTED CAMERA

            PickCameraForm form = new PickCameraForm();
            DisableReviewControls();

            form.ShowDialog();

            if (form.selected_camera != null)
            {
                ThreadFactory.StartReviewFootageThreadsUsingCamera(form.selected_camera);
                Debug.WriteLine("Enabling review controls 1");
                EnableReviewControls();
                Debug.WriteLine("Enabling review controls 2");
            }

            Debug.WriteLine("Enabling review controls 3");
            EnableReviewControls();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


     

    

       


    }
}
