﻿using Emgu.CV.UI;
namespace MetroFramework.Demo
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.show_detected_faces = new MetroFramework.Controls.MetroCheckBox();
            this.stop_button_1 = new MetroFramework.Controls.MetroButton();
            this.turn_on_button = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.total_time_label = new System.Windows.Forms.Label();
            this.time_elapsed_label = new System.Windows.Forms.Label();
            this.review_footage_color_slider = new MB.Controls.ColorSlider();
            this.panel_for_detected_faces = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comparison_picture_box = new System.Windows.Forms.PictureBox();
            this.suspects_picture_box = new System.Windows.Forms.PictureBox();
            this.review_footage_image_box = new Emgu.CV.UI.ImageBox();
            this.stop_button_2 = new MetroFramework.Controls.MetroButton();
            this.pick_video_button = new MetroFramework.Controls.MetroButton();
            this.show_detected_faces2 = new MetroFramework.Controls.MetroCheckBox();
            this.pause_button = new MetroFramework.Controls.MetroButton();
            this.metroTabPage11 = new MetroFramework.Controls.MetroTabPage();
            this.metroTile8 = new MetroFramework.Controls.MetroTile();
            this.metroTile7 = new MetroFramework.Controls.MetroTile();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.tile1 = new MetroFramework.Controls.MetroTile();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.metroStyleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.icons_list = new System.Windows.Forms.ImageList(this.components);
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.panel_for_detected_faces.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparison_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suspects_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).BeginInit();
            this.metroTabPage11.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage11);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 3;
            this.metroTabControl1.Size = new System.Drawing.Size(926, 445);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.AutoScroll = true;
            this.metroTabPage1.Controls.Add(this.label5);
            this.metroTabPage1.Controls.Add(this.label4);
            this.metroTabPage1.Controls.Add(this.label3);
            this.metroTabPage1.Controls.Add(this.label2);
            this.metroTabPage1.Controls.Add(this.show_detected_faces);
            this.metroTabPage1.Controls.Add(this.stop_button_1);
            this.metroTabPage1.Controls.Add(this.turn_on_button);
            this.metroTabPage1.HorizontalScrollbar = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage1.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Live Stream";
            this.metroTabPage1.VerticalScrollbar = true;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // label5
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label5, true);
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Camera 4";
            // 
            // label4
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label4, true);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Camera 2";
            // 
            // label3
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Camera 3";
            // 
            // label2
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label2, true);
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Camera 1";
            // 
            // show_detected_faces
            // 
            this.show_detected_faces.AutoSize = true;
            this.show_detected_faces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_detected_faces.Location = new System.Drawing.Point(529, 3);
            this.show_detected_faces.Name = "show_detected_faces";
            this.show_detected_faces.Size = new System.Drawing.Size(134, 15);
            this.show_detected_faces.TabIndex = 10;
            this.show_detected_faces.Text = "Show Detected Faces";
            this.metroToolTip.SetToolTip(this.show_detected_faces, "Checkbox Tooltip");
            this.show_detected_faces.UseSelectable = true;
            // 
            // stop_button_1
            // 
            this.stop_button_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop_button_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button_1.Location = new System.Drawing.Point(112, 363);
            this.stop_button_1.Name = "stop_button_1";
            this.stop_button_1.Size = new System.Drawing.Size(98, 37);
            this.stop_button_1.TabIndex = 9;
            this.stop_button_1.Text = "Stop";
            this.metroToolTip.SetToolTip(this.stop_button_1, "Button Tooltip");
            this.stop_button_1.UseSelectable = true;
            // 
            // turn_on_button
            // 
            this.turn_on_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turn_on_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.turn_on_button.Location = new System.Drawing.Point(3, 363);
            this.turn_on_button.Name = "turn_on_button";
            this.turn_on_button.Size = new System.Drawing.Size(103, 37);
            this.turn_on_button.TabIndex = 5;
            this.turn_on_button.Text = "Turn On";
            this.metroToolTip.SetToolTip(this.turn_on_button, "Button Tooltip");
            this.turn_on_button.UseSelectable = true;
            this.turn_on_button.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.AutoScroll = true;
            this.metroTabPage2.Controls.Add(this.total_time_label);
            this.metroTabPage2.Controls.Add(this.time_elapsed_label);
            this.metroTabPage2.Controls.Add(this.review_footage_color_slider);
            this.metroTabPage2.Controls.Add(this.panel_for_detected_faces);
            this.metroTabPage2.Controls.Add(this.review_footage_image_box);
            this.metroTabPage2.Controls.Add(this.stop_button_2);
            this.metroTabPage2.Controls.Add(this.pick_video_button);
            this.metroTabPage2.Controls.Add(this.show_detected_faces2);
            this.metroTabPage2.Controls.Add(this.pause_button);
            this.metroTabPage2.HorizontalScrollbar = true;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Padding = new System.Windows.Forms.Padding(25);
            this.metroTabPage2.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabPage2.TabIndex = 2;
            this.metroTabPage2.Text = "Review Footage";
            this.metroTabPage2.VerticalScrollbar = true;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Visible = false;
            // 
            // total_time_label
            // 
            this.total_time_label.AutoSize = true;
            this.total_time_label.Location = new System.Drawing.Point(374, 343);
            this.total_time_label.Name = "total_time_label";
            this.total_time_label.Size = new System.Drawing.Size(49, 13);
            this.total_time_label.TabIndex = 25;
            this.total_time_label.Text = "00:00:00";
            // 
            // time_elapsed_label
            // 
            this.time_elapsed_label.AutoSize = true;
            this.time_elapsed_label.Location = new System.Drawing.Point(4, 344);
            this.time_elapsed_label.Name = "time_elapsed_label";
            this.time_elapsed_label.Size = new System.Drawing.Size(49, 13);
            this.time_elapsed_label.TabIndex = 24;
            this.time_elapsed_label.Text = "00:00:00";
            // 
            // review_footage_color_slider
            // 
            this.review_footage_color_slider.BackColor = System.Drawing.Color.Transparent;
            this.review_footage_color_slider.BarInnerColor = System.Drawing.Color.White;
            this.review_footage_color_slider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.review_footage_color_slider.ElapsedInnerColor = System.Drawing.Color.Red;
            this.review_footage_color_slider.ElapsedOuterColor = System.Drawing.Color.Maroon;
            this.review_footage_color_slider.LargeChange = ((uint)(5u));
            this.review_footage_color_slider.Location = new System.Drawing.Point(4, 317);
            this.review_footage_color_slider.Name = "review_footage_color_slider";
            this.review_footage_color_slider.Size = new System.Drawing.Size(419, 23);
            this.review_footage_color_slider.SmallChange = ((uint)(1u));
            this.review_footage_color_slider.TabIndex = 23;
            this.review_footage_color_slider.Text = "colorSlider2";
            this.review_footage_color_slider.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.review_footage_color_slider.Value = 0;
            this.review_footage_color_slider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);
            // 
            // panel_for_detected_faces
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.panel_for_detected_faces, true);
            this.panel_for_detected_faces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_for_detected_faces.Controls.Add(this.label14);
            this.panel_for_detected_faces.Controls.Add(this.tableLayoutPanel1);
            this.panel_for_detected_faces.Location = new System.Drawing.Point(439, 47);
            this.panel_for_detected_faces.Name = "panel_for_detected_faces";
            this.panel_for_detected_faces.Size = new System.Drawing.Size(272, 338);
            this.panel_for_detected_faces.TabIndex = 22;
            // 
            // label14
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.label14, true);
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "FACE COMPARISON ONGOING";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.comparison_picture_box, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.suspects_picture_box, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comparison_picture_box
            // 
            this.comparison_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comparison_picture_box.Location = new System.Drawing.Point(123, 6);
            this.comparison_picture_box.Name = "comparison_picture_box";
            this.comparison_picture_box.Size = new System.Drawing.Size(109, 107);
            this.comparison_picture_box.TabIndex = 1;
            this.comparison_picture_box.TabStop = false;
            // 
            // suspects_picture_box
            // 
            this.suspects_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.suspects_picture_box.Location = new System.Drawing.Point(6, 6);
            this.suspects_picture_box.Name = "suspects_picture_box";
            this.suspects_picture_box.Size = new System.Drawing.Size(108, 107);
            this.suspects_picture_box.TabIndex = 0;
            this.suspects_picture_box.TabStop = false;
            // 
            // review_footage_image_box
            // 
            this.metroStyleExtender.SetApplyMetroTheme(this.review_footage_image_box, true);
            this.review_footage_image_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.review_footage_image_box.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.review_footage_image_box.Location = new System.Drawing.Point(4, 16);
            this.review_footage_image_box.Name = "review_footage_image_box";
            this.review_footage_image_box.Size = new System.Drawing.Size(419, 325);
            this.review_footage_image_box.TabIndex = 2;
            this.review_footage_image_box.TabStop = false;
            this.review_footage_image_box.Click += new System.EventHandler(this.review_footage_image_box_Click);
            // 
            // stop_button_2
            // 
            this.stop_button_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stop_button_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_button_2.Location = new System.Drawing.Point(109, 363);
            this.stop_button_2.Name = "stop_button_2";
            this.stop_button_2.Size = new System.Drawing.Size(103, 37);
            this.stop_button_2.TabIndex = 19;
            this.stop_button_2.Text = "Stop ";
            this.metroToolTip.SetToolTip(this.stop_button_2, "Button Tooltip");
            this.stop_button_2.UseSelectable = true;
            this.stop_button_2.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // pick_video_button
            // 
            this.pick_video_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pick_video_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pick_video_button.Location = new System.Drawing.Point(320, 363);
            this.pick_video_button.Name = "pick_video_button";
            this.pick_video_button.Size = new System.Drawing.Size(103, 37);
            this.pick_video_button.TabIndex = 15;
            this.pick_video_button.Text = "Pick Video";
            this.metroToolTip.SetToolTip(this.pick_video_button, "Button Tooltip");
            this.pick_video_button.UseSelectable = true;
            this.pick_video_button.Click += new System.EventHandler(this.pick_video_button_Click);
            // 
            // show_detected_faces2
            // 
            this.show_detected_faces2.AutoSize = true;
            this.show_detected_faces2.Location = new System.Drawing.Point(439, 16);
            this.show_detected_faces2.Name = "show_detected_faces2";
            this.show_detected_faces2.Size = new System.Drawing.Size(134, 15);
            this.show_detected_faces2.TabIndex = 14;
            this.show_detected_faces2.Text = "Show Detected Faces";
            this.metroToolTip.SetToolTip(this.show_detected_faces2, "Checkbox Tooltip");
            this.show_detected_faces2.UseSelectable = true;
            this.show_detected_faces2.CheckedChanged += new System.EventHandler(this.show_detected_faces2_CheckedChanged);
            // 
            // pause_button
            // 
            this.pause_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pause_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_button.Location = new System.Drawing.Point(0, 363);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(103, 37);
            this.pause_button.TabIndex = 11;
            this.pause_button.Text = "Pause ";
            this.metroToolTip.SetToolTip(this.pause_button, "Button Tooltip");
            this.pause_button.UseSelectable = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // metroTabPage11
            // 
            this.metroTabPage11.BackColor = System.Drawing.Color.Silver;
            this.metroTabPage11.Controls.Add(this.metroTile8);
            this.metroTabPage11.Controls.Add(this.metroTile7);
            this.metroTabPage11.Controls.Add(this.metroTile6);
            this.metroTabPage11.Controls.Add(this.metroTile3);
            this.metroTabPage11.Controls.Add(this.metroTile5);
            this.metroTabPage11.Controls.Add(this.metroTile4);
            this.metroTabPage11.Controls.Add(this.metroTile2);
            this.metroTabPage11.Controls.Add(this.metroTile1);
            this.metroTabPage11.Controls.Add(this.tile1);
            this.metroTabPage11.HorizontalScrollbarBarColor = true;
            this.metroTabPage11.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage11.HorizontalScrollbarSize = 10;
            this.metroTabPage11.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage11.Name = "metroTabPage11";
            this.metroTabPage11.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage11.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroTabPage11.TabIndex = 6;
            this.metroTabPage11.Text = "Settings";
            this.metroTabPage11.VerticalScrollbarBarColor = true;
            this.metroTabPage11.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage11.VerticalScrollbarSize = 10;
            //this.metroTabPage11.Click += new System.EventHandler(this.metroTabPage11_Click);
            // 
            // metroTile8
            // 
            this.metroTile8.ActiveControl = null;
            this.metroTile8.Location = new System.Drawing.Point(568, 252);
            this.metroTile8.Name = "metroTile8";
            this.metroTile8.Size = new System.Drawing.Size(225, 108);
            this.metroTile8.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroTile8.TabIndex = 11;
            this.metroTile8.Text = "About Us";
            this.metroTile8.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile8.TileImage")));
            this.metroTile8.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile8.UseSelectable = true;
            this.metroTile8.UseTileImage = true;
            // 
            // metroTile7
            // 
            this.metroTile7.ActiveControl = null;
            this.metroTile7.Location = new System.Drawing.Point(342, 251);
            this.metroTile7.Name = "metroTile7";
            this.metroTile7.Size = new System.Drawing.Size(220, 108);
            this.metroTile7.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroTile7.TabIndex = 10;
            this.metroTile7.Text = "Most Wanted List";
            this.metroTile7.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile7.TileImage")));
            this.metroTile7.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile7.UseSelectable = true;
            this.metroTile7.UseTileImage = true;
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Location = new System.Drawing.Point(105, 251);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(231, 108);
            this.metroTile6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile6.TabIndex = 9;
            this.metroTile6.Text = "Help";
            this.metroTile6.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile6.TileImage")));
            this.metroTile6.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.UseSelectable = true;
            this.metroTile6.UseTileImage = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(568, 137);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(225, 109);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile3.TabIndex = 8;
            this.metroTile3.Text = "History";
            this.metroTile3.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile3.TileImage")));
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.UseSelectable = true;
            this.metroTile3.UseTileImage = true;
            // 
            // metroTile5
            // 
            this.metroTile5.ActiveControl = null;
            this.metroTile5.Location = new System.Drawing.Point(342, 136);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(220, 109);
            this.metroTile5.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroTile5.TabIndex = 7;
            this.metroTile5.Text = "DashBoard";
            this.metroTile5.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile5.TileImage")));
            this.metroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.UseSelectable = true;
            this.metroTile5.UseTileImage = true;
            this.metroTile5.Click += new System.EventHandler(this.metroTile5_Click);
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(568, 26);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(225, 104);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroTile4.TabIndex = 6;
            this.metroTile4.Text = "Change User role";
            this.metroTile4.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile4.TileImage")));
            this.metroTile4.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile4.UseSelectable = true;
            this.metroTile4.UseTileImage = true;
            this.metroTile4.Click += new System.EventHandler(this.metroTile4_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(105, 137);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(231, 108);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile2.TabIndex = 4;
            this.metroTile2.Text = "Add Student";
            this.metroTile2.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile2.TileImage")));
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(342, 26);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(220, 104);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTile1.TabIndex = 3;
            this.metroTile1.Text = "Change Login Credentials";
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // tile1
            // 
            this.tile1.ActiveControl = null;
            this.tile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tile1.BackColor = System.Drawing.SystemColors.GrayText;
            this.tile1.ContextMenuStrip = this.metroContextMenu1;
            this.tile1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tile1.Location = new System.Drawing.Point(105, 26);
            this.tile1.Name = "tile1";
            this.tile1.Size = new System.Drawing.Size(231, 104);
            this.tile1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tile1.TabIndex = 2;
            this.tile1.Text = "Add User";
            this.tile1.TileImage = ((System.Drawing.Image)(resources.GetObject("tile1.TileImage")));
            this.tile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tile1.UseSelectable = true;
            this.tile1.UseStyleColors = true;
            this.tile1.UseTileImage = true;
            this.tile1.Click += new System.EventHandler(this.tile1_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(144, 120);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detected Faces";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToolTip
            // 
            this.metroToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip.StyleManager = null;
            this.metroToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // icons_list
            // 
            this.icons_list.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons_list.ImageStream")));
            this.icons_list.TransparentColor = System.Drawing.Color.Transparent;
            this.icons_list.Images.SetKeyName(0, "about-us.png");
            this.icons_list.Images.SetKeyName(1, "cam4.png");
            this.icons_list.Images.SetKeyName(2, "help.png");
            this.icons_list.Images.SetKeyName(3, "replay1.png");
            this.icons_list.Images.SetKeyName(4, "settings.png");
            this.icons_list.Images.SetKeyName(5, "thief1.png");
            this.icons_list.Images.SetKeyName(6, "wanted1.png");
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.button1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(918, 400);
            this.metroTabPage3.TabIndex = 7;
            this.metroTabPage3.Text = "metroTabPage3";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::MetroFramework.Demo.Properties.Resources.GitHub_Mark;
            this.BackImagePadding = new System.Windows.Forms.Padding(210, 10, 0, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(966, 525);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StyleManager = this.metroStyleManager;
            this.Text = "Nkujukira";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.panel_for_detected_faces.ResumeLayout(false);
            this.panel_for_detected_faces.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comparison_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suspects_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.review_footage_image_box)).EndInit();
            this.metroTabPage11.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion


        #region Controls
        private Controls.MetroTabControl metroTabControl1;
        private Components.MetroStyleManager metroStyleManager;
        private Controls.MetroTabPage metroTabPage1;
        private Components.MetroToolTip metroToolTip;
        private Controls.MetroButton turn_on_button;
        private Components.MetroStyleExtender metroStyleExtender;
        private Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Controls.MetroCheckBox show_detected_faces;
        private Controls.MetroButton stop_button_1;
        public static Emgu.CV.UI.ImageBox live_stream_imageBox;
        #endregion
        private Controls.MetroTabPage metroTabPage2;
        private Controls.MetroButton stop_button_2;
        private Controls.MetroButton pick_video_button;
        private Controls.MetroCheckBox show_detected_faces2;
        private Controls.MetroButton pause_button;
        public static MB.Controls.ColorSlider slider_review_footage;
        public static System.Windows.Forms.Label video_total_time_label;
        public static System.Windows.Forms.Label elapsed_time_label;
        private System.Windows.Forms.ImageList icons_list;
        public static System.Windows.Forms.Panel detected_faces_panel;
        public static Emgu.CV.UI.ImageBox imageBox3;
        public static Emgu.CV.UI.ImageBox imageBox2;
        public static Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ImageBox review_footage_image_box;
        private System.Windows.Forms.Panel panel_for_detected_faces;
        private MB.Controls.ColorSlider review_footage_color_slider;
        private System.Windows.Forms.Label total_time_label;
        private System.Windows.Forms.Label time_elapsed_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox comparison_picture_box;
        private System.Windows.Forms.PictureBox suspects_picture_box;
        private System.Windows.Forms.Label label14;
        private Controls.MetroTabPage metroTabPage11;
        private Controls.MetroTile metroTile8;
        private Controls.MetroTile metroTile7;
        private Controls.MetroTile metroTile6;
        private Controls.MetroTile metroTile3;
        private Controls.MetroTile metroTile5;
        private Controls.MetroTile metroTile4;
        private Controls.MetroTile metroTile2;
        private Controls.MetroTile metroTile1;
        private Controls.MetroTile tile1;
        private Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Button button1;
        
     




    }
}

