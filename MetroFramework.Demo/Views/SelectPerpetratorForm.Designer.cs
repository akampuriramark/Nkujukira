﻿namespace Nkujukira.Demo
{
    partial class SelectPerpetratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.perpetrator_frame_picture_box = new System.Windows.Forms.PictureBox();
            this.done_button = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_separator = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_frame_picture_box)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // perpetrator_frame_picture_box
            // 
            this.perpetrator_frame_picture_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.perpetrator_frame_picture_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.perpetrator_frame_picture_box.Location = new System.Drawing.Point(12, 9);
            this.perpetrator_frame_picture_box.Name = "perpetrator_frame_picture_box";
            this.perpetrator_frame_picture_box.Size = new System.Drawing.Size(379, 281);
            this.perpetrator_frame_picture_box.TabIndex = 4;
            this.perpetrator_frame_picture_box.TabStop = false;
            this.perpetrator_frame_picture_box.Paint += new System.Windows.Forms.PaintEventHandler(this.perpetrator_frame_picture_box_Paint);
            this.perpetrator_frame_picture_box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseDown);
            this.perpetrator_frame_picture_box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseMove);
            this.perpetrator_frame_picture_box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.perpetrator_frame_picture_box_MouseUp);
            // 
            // done_button
            // 
            this.done_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.done_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.done_button.Location = new System.Drawing.Point(133, 321);
            this.done_button.Name = "done_button";
            this.done_button.Size = new System.Drawing.Size(141, 37);
            this.done_button.TabIndex = 20;
            this.done_button.Text = "Done!!";
            this.done_button.UseSelectable = true;
            this.done_button.Click += new System.EventHandler(this.done_button_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_separator);
            this.panel1.Controls.Add(this.perpetrator_frame_picture_box);
            this.panel1.Controls.Add(this.done_button);
            this.panel1.Location = new System.Drawing.Point(9, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 367);
            this.panel1.TabIndex = 21;
            // 
            // label_separator
            // 
            this.label_separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_separator.Location = new System.Drawing.Point(-1, 307);
            this.label_separator.Name = "label_separator";
            this.label_separator.Size = new System.Drawing.Size(401, 2);
            this.label_separator.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(-33, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(477, 1);
            this.label10.TabIndex = 40;
            // 
            // SelectPerpetratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(423, 436);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPerpetratorForm";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Select The Face of the Perpetrator";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            ((System.ComponentModel.ISupportInitialize)(this.perpetrator_frame_picture_box)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox perpetrator_frame_picture_box;
        private MetroFramework.Controls.MetroButton done_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_separator;
        private System.Windows.Forms.Label label10;

    }
}