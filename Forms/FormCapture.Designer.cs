namespace ADAL_Video.Forms
{
    partial class FormCapture
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
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.modeLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currTimeLbl = new System.Windows.Forms.Label();
            this.DurationLbl = new System.Windows.Forms.Label();
            this.TimerPosition = new System.Windows.Forms.Timer(this.components);
            this.RstatusLbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.fastRecCam2 = new System.Windows.Forms.Button();
            this.fastRecCam1 = new System.Windows.Forms.Button();
            this.fastAudioRec = new System.Windows.Forms.Button();
            this.startRecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Обследуемый:";
            // 
            // ID
            // 
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID.Location = new System.Drawing.Point(118, 76);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(346, 22);
            this.ID.TabIndex = 2;
            // 
            // modeLbl
            // 
            this.modeLbl.AutoSize = true;
            this.modeLbl.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLbl.Location = new System.Drawing.Point(8, 118);
            this.modeLbl.Name = "modeLbl";
            this.modeLbl.Size = new System.Drawing.Size(112, 20);
            this.modeLbl.TabIndex = 39;
            this.modeLbl.Text = "Режим записи:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(619, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 92;
            this.label6.Text = "/";
            // 
            // currTimeLbl
            // 
            this.currTimeLbl.AutoSize = true;
            this.currTimeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.currTimeLbl.Location = new System.Drawing.Point(549, 15);
            this.currTimeLbl.Name = "currTimeLbl";
            this.currTimeLbl.Size = new System.Drawing.Size(64, 17);
            this.currTimeLbl.TabIndex = 91;
            this.currTimeLbl.Text = "00:00:00";
            // 
            // DurationLbl
            // 
            this.DurationLbl.AutoSize = true;
            this.DurationLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DurationLbl.Location = new System.Drawing.Point(637, 15);
            this.DurationLbl.Name = "DurationLbl";
            this.DurationLbl.Size = new System.Drawing.Size(64, 17);
            this.DurationLbl.TabIndex = 90;
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
            this.RstatusLbl.TabIndex = 94;
            this.RstatusLbl.Text = "Инициализация";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(521, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 93;
            this.label10.Text = "Cтатус:";
            // 
            // pauseBtn
            // 
            this.pauseBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.play_or_pause_button;
            this.pauseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pauseBtn.FlatAppearance.BorderSize = 0;
            this.pauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseBtn.Location = new System.Drawing.Point(302, 12);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(50, 50);
            this.pauseBtn.TabIndex = 89;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.stop;
            this.stopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stopBtn.FlatAppearance.BorderSize = 0;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Location = new System.Drawing.Point(358, 12);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(50, 50);
            this.stopBtn.TabIndex = 88;
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.preview;
            this.PreviewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PreviewBtn.FlatAppearance.BorderSize = 0;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Location = new System.Drawing.Point(12, 12);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(50, 50);
            this.PreviewBtn.TabIndex = 87;
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // fastRecCam2
            // 
            this.fastRecCam2.BackgroundImage = global::ADAL_Video.Properties.Resources.fast_webcam_record;
            this.fastRecCam2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fastRecCam2.FlatAppearance.BorderSize = 0;
            this.fastRecCam2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastRecCam2.Location = new System.Drawing.Point(180, 12);
            this.fastRecCam2.Name = "fastRecCam2";
            this.fastRecCam2.Size = new System.Drawing.Size(50, 50);
            this.fastRecCam2.TabIndex = 86;
            this.fastRecCam2.UseVisualStyleBackColor = true;
            this.fastRecCam2.Click += new System.EventHandler(this.FastRecCam2_Click);
            // 
            // fastRecCam1
            // 
            this.fastRecCam1.BackgroundImage = global::ADAL_Video.Properties.Resources.fast_camera_record;
            this.fastRecCam1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fastRecCam1.FlatAppearance.BorderSize = 0;
            this.fastRecCam1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastRecCam1.Location = new System.Drawing.Point(124, 12);
            this.fastRecCam1.Name = "fastRecCam1";
            this.fastRecCam1.Size = new System.Drawing.Size(50, 50);
            this.fastRecCam1.TabIndex = 85;
            this.fastRecCam1.UseVisualStyleBackColor = true;
            this.fastRecCam1.Click += new System.EventHandler(this.FastRecCam1_Click);
            // 
            // fastAudioRec
            // 
            this.fastAudioRec.BackgroundImage = global::ADAL_Video.Properties.Resources.fast_micro_record;
            this.fastAudioRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fastAudioRec.FlatAppearance.BorderSize = 0;
            this.fastAudioRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastAudioRec.Location = new System.Drawing.Point(68, 12);
            this.fastAudioRec.Name = "fastAudioRec";
            this.fastAudioRec.Size = new System.Drawing.Size(50, 50);
            this.fastAudioRec.TabIndex = 84;
            this.fastAudioRec.UseVisualStyleBackColor = true;
            this.fastAudioRec.Click += new System.EventHandler(this.FastAudioRec_Click);
            // 
            // startRecBtn
            // 
            this.startRecBtn.BackgroundImage = global::ADAL_Video.Properties.Resources.record_button;
            this.startRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startRecBtn.FlatAppearance.BorderSize = 0;
            this.startRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startRecBtn.Location = new System.Drawing.Point(236, 12);
            this.startRecBtn.Name = "startRecBtn";
            this.startRecBtn.Size = new System.Drawing.Size(50, 50);
            this.startRecBtn.TabIndex = 83;
            this.startRecBtn.UseVisualStyleBackColor = true;
            this.startRecBtn.Click += new System.EventHandler(this.StartRecBtn_Click);
            // 
            // FormCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 767);
            this.Controls.Add(this.RstatusLbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.currTimeLbl);
            this.Controls.Add(this.DurationLbl);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.fastRecCam2);
            this.Controls.Add(this.fastRecCam1);
            this.Controls.Add(this.fastAudioRec);
            this.Controls.Add(this.startRecBtn);
            this.Controls.Add(this.modeLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID);
            this.Name = "FormCapture";
            this.Text = "Запись";
            this.Load += new System.EventHandler(this.FormCapture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label modeLbl;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button fastRecCam2;
        private System.Windows.Forms.Button fastRecCam1;
        private System.Windows.Forms.Button fastAudioRec;
        private System.Windows.Forms.Button startRecBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currTimeLbl;
        private System.Windows.Forms.Label DurationLbl;
        private System.Windows.Forms.Timer TimerPosition;
        private System.Windows.Forms.Label RstatusLbl;
        private System.Windows.Forms.Label label10;
    }
}