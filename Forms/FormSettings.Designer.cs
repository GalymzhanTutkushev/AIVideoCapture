namespace ADAL_Video.Forms
{
    partial class FormSettings
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
            this.recAudio = new System.Windows.Forms.CheckBox();
            this.CamSet2 = new System.Windows.Forms.ComboBox();
            this.CamSet1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.videoBox1 = new System.Windows.Forms.ComboBox();
            this.videoBox2 = new System.Windows.Forms.ComboBox();
            this.audioBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormatLbl = new System.Windows.Forms.Label();
            this.FormatBox = new System.Windows.Forms.ComboBox();
            this.ClearWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recAudio
            // 
            this.recAudio.AutoSize = true;
            this.recAudio.Location = new System.Drawing.Point(418, 43);
            this.recAudio.Name = "recAudio";
            this.recAudio.Size = new System.Drawing.Size(246, 21);
            this.recAudio.TabIndex = 48;
            this.recAudio.Text = "Записать отдельный аудиофайл";
            this.recAudio.UseVisualStyleBackColor = true;
            // 
            // CamSet2
            // 
            this.CamSet2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamSet2.FormattingEnabled = true;
            this.CamSet2.Location = new System.Drawing.Point(527, 172);
            this.CamSet2.Name = "CamSet2";
            this.CamSet2.Size = new System.Drawing.Size(118, 24);
            this.CamSet2.TabIndex = 47;
            // 
            // CamSet1
            // 
            this.CamSet1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CamSet1.FormattingEnabled = true;
            this.CamSet1.Location = new System.Drawing.Point(527, 109);
            this.CamSet1.Name = "CamSet1";
            this.CamSet1.Size = new System.Drawing.Size(118, 24);
            this.CamSet1.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Качество №2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(414, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 44;
            this.label7.Text = "Качество №1:";
            // 
            // videoBox1
            // 
            this.videoBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoBox1.FormattingEnabled = true;
            this.videoBox1.Location = new System.Drawing.Point(112, 109);
            this.videoBox1.Name = "videoBox1";
            this.videoBox1.Size = new System.Drawing.Size(285, 24);
            this.videoBox1.TabIndex = 43;
            this.videoBox1.SelectedIndexChanged += new System.EventHandler(this.VideoBox1_SelectedIndexChanged);
            // 
            // videoBox2
            // 
            this.videoBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoBox2.FormattingEnabled = true;
            this.videoBox2.Location = new System.Drawing.Point(112, 172);
            this.videoBox2.Name = "videoBox2";
            this.videoBox2.Size = new System.Drawing.Size(285, 24);
            this.videoBox2.TabIndex = 42;
            this.videoBox2.SelectedIndexChanged += new System.EventHandler(this.VideoBox1_SelectedIndexChanged);
            // 
            // audioBox
            // 
            this.audioBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioBox.FormattingEnabled = true;
            this.audioBox.Location = new System.Drawing.Point(112, 40);
            this.audioBox.Name = "audioBox";
            this.audioBox.Size = new System.Drawing.Size(285, 24);
            this.audioBox.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Камера №2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Микрофон:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Камера №1:";
            // 
            // FormatLbl
            // 
            this.FormatLbl.AutoSize = true;
            this.FormatLbl.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatLbl.Location = new System.Drawing.Point(407, 228);
            this.FormatLbl.Name = "FormatLbl";
            this.FormatLbl.Size = new System.Drawing.Size(114, 20);
            this.FormatLbl.TabIndex = 88;
            this.FormatLbl.Text = "Медиаформат:";
            // 
            // FormatBox
            // 
            this.FormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox.FormattingEnabled = true;
            this.FormatBox.Location = new System.Drawing.Point(527, 228);
            this.FormatBox.Name = "FormatBox";
            this.FormatBox.Size = new System.Drawing.Size(118, 24);
            this.FormatBox.TabIndex = 87;
            // 
            // ClearWindow
            // 
            this.ClearWindow.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClearWindow.BackgroundImage = global::ADAL_Video.Properties.Resources.clear;
            this.ClearWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClearWindow.FlatAppearance.BorderSize = 0;
            this.ClearWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearWindow.Location = new System.Drawing.Point(562, 277);
            this.ClearWindow.Name = "ClearWindow";
            this.ClearWindow.Size = new System.Drawing.Size(50, 50);
            this.ClearWindow.TabIndex = 91;
            this.ClearWindow.UseVisualStyleBackColor = false;
            this.ClearWindow.Click += new System.EventHandler(this.ClearWindow_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormatBox);
            this.Controls.Add(this.FormatLbl);
            this.Controls.Add(this.ClearWindow);
            this.Controls.Add(this.recAudio);
            this.Controls.Add(this.CamSet2);
            this.Controls.Add(this.CamSet1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.videoBox1);
            this.Controls.Add(this.videoBox2);
            this.Controls.Add(this.audioBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox recAudio;
        private System.Windows.Forms.ComboBox CamSet2;
        private System.Windows.Forms.ComboBox CamSet1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox videoBox1;
        private System.Windows.Forms.ComboBox videoBox2;
        private System.Windows.Forms.ComboBox audioBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FormatLbl;
        private System.Windows.Forms.ComboBox FormatBox;
        private System.Windows.Forms.Button ClearWindow;
    }
}