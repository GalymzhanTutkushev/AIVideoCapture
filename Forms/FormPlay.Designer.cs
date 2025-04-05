namespace ADAL_Video.Forms
{
    partial class FormPlay
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
            this.components = new System.ComponentModel.Container();
            this.PlayPanel = new System.Windows.Forms.Panel();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.GoToPos = new System.Windows.Forms.Button();
            this.PositionTracker = new System.Windows.Forms.TrackBar();
            this.slowBtn = new System.Windows.Forms.Button();
            this.fastBtn = new System.Windows.Forms.Button();
            this.rateLbl = new System.Windows.Forms.Label();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.currTimeLbl = new System.Windows.Forms.Label();
            this.DurationLbl = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TimerPosition = new System.Windows.Forms.Timer(this.components);
            this.RstatusLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.stepFrameBtn = new System.Windows.Forms.Button();
            this.saveFrameBtn = new System.Windows.Forms.Button();
            this.saveFrameBtn2 = new System.Windows.Forms.Button();
            this.volumePic = new System.Windows.Forms.PictureBox();
            this.PlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumePic)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayPanel
            // 
            this.PlayPanel.Controls.Add(this.TimePicker);
            this.PlayPanel.Controls.Add(this.GoToPos);
            this.PlayPanel.Controls.Add(this.PositionTracker);
            this.PlayPanel.Controls.Add(this.slowBtn);
            this.PlayPanel.Controls.Add(this.fastBtn);
            this.PlayPanel.Controls.Add(this.rateLbl);
            this.PlayPanel.Location = new System.Drawing.Point(12, 78);
            this.PlayPanel.Name = "PlayPanel";
            this.PlayPanel.Size = new System.Drawing.Size(693, 70);
            this.PlayPanel.TabIndex = 87;
            // 
            // TimePicker
            // 
            this.TimePicker.CalendarFont = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(597, 2);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.ShowUpDown = true;
            this.TimePicker.Size = new System.Drawing.Size(90, 22);
            this.TimePicker.TabIndex = 81;
            this.TimePicker.Value = new System.DateTime(2021, 9, 19, 0, 0, 0, 0);
            // 
            // GoToPos
            // 
            this.GoToPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GoToPos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GoToPos.Location = new System.Drawing.Point(607, 30);
            this.GoToPos.Name = "GoToPos";
            this.GoToPos.Size = new System.Drawing.Size(80, 32);
            this.GoToPos.TabIndex = 52;
            this.GoToPos.Text = "Перейти";
            this.GoToPos.UseVisualStyleBackColor = true;
            this.GoToPos.Click += new System.EventHandler(this.GoToPos_Click);
            // 
            // PositionTracker
            // 
            this.PositionTracker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PositionTracker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PositionTracker.LargeChange = 1;
            this.PositionTracker.Location = new System.Drawing.Point(152, 6);
            this.PositionTracker.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.PositionTracker.Name = "PositionTracker";
            this.PositionTracker.Size = new System.Drawing.Size(439, 56);
            this.PositionTracker.TabIndex = 50;
            this.PositionTracker.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.PositionTracker.Scroll += new System.EventHandler(this.PositionTracker_Scroll);
            // 
            // slowBtn
            // 
            this.slowBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.left;
            this.slowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.slowBtn.FlatAppearance.BorderSize = 0;
            this.slowBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slowBtn.Location = new System.Drawing.Point(3, 6);
            this.slowBtn.Name = "slowBtn";
            this.slowBtn.Size = new System.Drawing.Size(40, 40);
            this.slowBtn.TabIndex = 43;
            this.slowBtn.UseMnemonic = false;
            this.slowBtn.UseVisualStyleBackColor = true;
            this.slowBtn.Click += new System.EventHandler(this.SlowBtn_Click);
            // 
            // fastBtn
            // 
            this.fastBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.right;
            this.fastBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fastBtn.FlatAppearance.BorderSize = 0;
            this.fastBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fastBtn.Location = new System.Drawing.Point(104, 6);
            this.fastBtn.Name = "fastBtn";
            this.fastBtn.Size = new System.Drawing.Size(40, 40);
            this.fastBtn.TabIndex = 44;
            this.fastBtn.UseVisualStyleBackColor = true;
            this.fastBtn.Click += new System.EventHandler(this.FastBtn_Click);
            // 
            // rateLbl
            // 
            this.rateLbl.AutoSize = true;
            this.rateLbl.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rateLbl.Location = new System.Drawing.Point(49, 15);
            this.rateLbl.Name = "rateLbl";
            this.rateLbl.Size = new System.Drawing.Size(40, 23);
            this.rateLbl.TabIndex = 46;
            this.rateLbl.Text = "1.0x";
            // 
            // VolumeBar
            // 
            this.VolumeBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VolumeBar.Location = new System.Drawing.Point(56, 16);
            this.VolumeBar.Maximum = 5;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(97, 56);
            this.VolumeBar.TabIndex = 84;
            this.VolumeBar.Tag = "";
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.VolumeBar.Value = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(623, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "/";
            // 
            // currTimeLbl
            // 
            this.currTimeLbl.AutoSize = true;
            this.currTimeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.currTimeLbl.Location = new System.Drawing.Point(553, 16);
            this.currTimeLbl.Name = "currTimeLbl";
            this.currTimeLbl.Size = new System.Drawing.Size(64, 17);
            this.currTimeLbl.TabIndex = 89;
            this.currTimeLbl.Text = "00:00:00";
            // 
            // DurationLbl
            // 
            this.DurationLbl.AutoSize = true;
            this.DurationLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DurationLbl.Location = new System.Drawing.Point(641, 16);
            this.DurationLbl.Name = "DurationLbl";
            this.DurationLbl.Size = new System.Drawing.Size(64, 17);
            this.DurationLbl.TabIndex = 88;
            this.DurationLbl.Text = "00:00:00";
            // 
            // TimerPosition
            // 
            this.TimerPosition.Enabled = true;
            this.TimerPosition.Interval = 1000;
            // 
            // RstatusLbl
            // 
            this.RstatusLbl.AutoSize = true;
            this.RstatusLbl.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RstatusLbl.Location = new System.Drawing.Point(585, 46);
            this.RstatusLbl.Name = "RstatusLbl";
            this.RstatusLbl.Size = new System.Drawing.Size(117, 20);
            this.RstatusLbl.TabIndex = 92;
            this.RstatusLbl.Text = "Инициализация";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(521, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 91;
            this.label10.Text = "Cтатус:";
            // 
            // stopBtn
            // 
            this.stopBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.stop;
            this.stopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stopBtn.FlatAppearance.BorderSize = 0;
            this.stopBtn.Location = new System.Drawing.Point(385, 15);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(50, 50);
            this.stopBtn.TabIndex = 93;
            this.stopBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.play_or_pause_button;
            this.pauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pauseBtn.FlatAppearance.BorderSize = 0;
            this.pauseBtn.Location = new System.Drawing.Point(329, 15);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(50, 50);
            this.pauseBtn.TabIndex = 94;
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // stepFrameBtn
            // 
            this.stepFrameBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.frames;
            this.stepFrameBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stepFrameBtn.FlatAppearance.BorderSize = 0;
            this.stepFrameBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stepFrameBtn.Location = new System.Drawing.Point(273, 16);
            this.stepFrameBtn.Name = "stepFrameBtn";
            this.stepFrameBtn.Size = new System.Drawing.Size(50, 50);
            this.stepFrameBtn.TabIndex = 53;
            this.stepFrameBtn.UseVisualStyleBackColor = true;
            this.stepFrameBtn.Click += new System.EventHandler(this.StepFrameBtn_Click);
            // 
            // saveFrameBtn
            // 
            this.saveFrameBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.screenshot1;
            this.saveFrameBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveFrameBtn.FlatAppearance.BorderSize = 0;
            this.saveFrameBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveFrameBtn.Location = new System.Drawing.Point(161, 17);
            this.saveFrameBtn.Name = "saveFrameBtn";
            this.saveFrameBtn.Size = new System.Drawing.Size(50, 50);
            this.saveFrameBtn.TabIndex = 54;
            this.saveFrameBtn.UseVisualStyleBackColor = true;
            this.saveFrameBtn.Click += new System.EventHandler(this.SaveFrameBtn_Click);
            // 
            // saveFrameBtn2
            // 
            this.saveFrameBtn2.BackgroundImage = global::ADAL_Video.Properties.Resources.screenshot2;
            this.saveFrameBtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveFrameBtn2.FlatAppearance.BorderSize = 0;
            this.saveFrameBtn2.Location = new System.Drawing.Point(217, 17);
            this.saveFrameBtn2.Name = "saveFrameBtn2";
            this.saveFrameBtn2.Size = new System.Drawing.Size(50, 50);
            this.saveFrameBtn2.TabIndex = 59;
            this.saveFrameBtn2.UseVisualStyleBackColor = true;
            this.saveFrameBtn2.Click += new System.EventHandler(this.SaveFrameBtn2_Click);
            // 
            // volumePic
            // 
            this.volumePic.BackgroundImage = global::ADAL_Video.Properties.Resources.volume;
            this.volumePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.volumePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volumePic.Location = new System.Drawing.Point(12, 26);
            this.volumePic.Name = "volumePic";
            this.volumePic.Size = new System.Drawing.Size(40, 40);
            this.volumePic.TabIndex = 85;
            this.volumePic.TabStop = false;
            this.volumePic.Click += new System.EventHandler(this.volumePic_Click);
            // 
            // FormPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 718);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.volumePic);
            this.Controls.Add(this.RstatusLbl);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.stepFrameBtn);
            this.Controls.Add(this.saveFrameBtn);
            this.Controls.Add(this.saveFrameBtn2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.currTimeLbl);
            this.Controls.Add(this.DurationLbl);
            this.Controls.Add(this.PlayPanel);
            this.Name = "FormPlay";
            this.Text = "Воспроизведение";
            this.PlayPanel.ResumeLayout(false);
            this.PlayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionTracker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayPanel;
        private System.Windows.Forms.PictureBox volumePic;
        private System.Windows.Forms.Button stepFrameBtn;
        private System.Windows.Forms.Button saveFrameBtn;
        private System.Windows.Forms.Button saveFrameBtn2;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Button slowBtn;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Label rateLbl;
        private System.Windows.Forms.Button fastBtn;
        private System.Windows.Forms.Button GoToPos;
        private System.Windows.Forms.TrackBar PositionTracker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currTimeLbl;
        private System.Windows.Forms.Label DurationLbl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer TimerPosition;
        private System.Windows.Forms.Label RstatusLbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button stopBtn;
    }
}