namespace ADAL_Video
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переместитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.HideTimeList = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxUSB = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnFiles = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.NoteCodeBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.EventCodeBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TimeList = new System.Windows.Forms.ListBox();
            this.AddConfession = new System.Windows.Forms.Button();
            this.TimeListPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddTimeCode = new System.Windows.Forms.Button();
            this.RenameTimeCode = new System.Windows.Forms.Button();
            this.DeleteTimeCode = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUSB)).BeginInit();
            this.TimeListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // переместитьToolStripMenuItem
            // 
            this.переместитьToolStripMenuItem.Name = "переместитьToolStripMenuItem";
            this.переместитьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.HideTimeList);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Controls.Add(this.pictureBoxUSB);
            this.panelMenu.Controls.Add(this.lblTitle);
            this.panelMenu.Controls.Add(this.btnHelp);
            this.panelMenu.Controls.Add(this.btnPlay);
            this.panelMenu.Controls.Add(this.btnFiles);
            this.panelMenu.Controls.Add(this.btnCapture);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 1000);
            this.panelMenu.TabIndex = 90;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(170, 832);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(44, 44);
            this.btnMenu.TabIndex = 97;
            this.btnMenu.Text = "button1";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // HideTimeList
            // 
            this.HideTimeList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.HideTimeList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HideTimeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.HideTimeList.FlatAppearance.BorderSize = 0;
            this.HideTimeList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideTimeList.Image = global::ADAL_Video.Properties.Resources.add_time_40;
            this.HideTimeList.Location = new System.Drawing.Point(0, 350);
            this.HideTimeList.Name = "HideTimeList";
            this.HideTimeList.Size = new System.Drawing.Size(220, 70);
            this.HideTimeList.TabIndex = 96;
            this.HideTimeList.Text = "    Таймкоды";
            this.HideTimeList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HideTimeList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HideTimeList.UseVisualStyleBackColor = false;
            this.HideTimeList.Click += new System.EventHandler(this.HideTimeList_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::ADAL_Video.Properties.Resources.logo;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Location = new System.Drawing.Point(4, 426);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 208);
            this.panelLogo.TabIndex = 6;
            // 
            // pictureBoxUSB
            // 
            this.pictureBoxUSB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxUSB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxUSB.InitialImage = null;
            this.pictureBoxUSB.Location = new System.Drawing.Point(4, 654);
            this.pictureBoxUSB.Name = "pictureBoxUSB";
            this.pictureBoxUSB.Size = new System.Drawing.Size(202, 172);
            this.pictureBoxUSB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUSB.TabIndex = 60;
            this.pictureBoxUSB.TabStop = false;
            this.pictureBoxUSB.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 977);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 23);
            this.lblTitle.TabIndex = 92;
            this.lblTitle.Text = "label1";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Image = global::ADAL_Video.Properties.Resources.help;
            this.btnHelp.Location = new System.Drawing.Point(0, 280);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(220, 70);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "     Справка";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = global::ADAL_Video.Properties.Resources.play_48;
            this.btnPlay.Location = new System.Drawing.Point(0, 210);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(220, 70);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "  Плеер";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFiles.FlatAppearance.BorderSize = 0;
            this.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiles.Image = global::ADAL_Video.Properties.Resources.playlist_48;
            this.btnFiles.Location = new System.Drawing.Point(0, 140);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(220, 70);
            this.btnFiles.TabIndex = 3;
            this.btnFiles.Text = "  Файлы";
            this.btnFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiles.UseVisualStyleBackColor = false;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Image = global::ADAL_Video.Properties.Resources.record_48;
            this.btnCapture.Location = new System.Drawing.Point(0, 70);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(220, 70);
            this.btnCapture.TabIndex = 2;
            this.btnCapture.Text = "  Запись";
            this.btnCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::ADAL_Video.Properties.Resources.settings;
            this.btnSettings.Location = new System.Drawing.Point(0, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(220, 70);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "  Настройки";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // NoteCodeBox
            // 
            this.NoteCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoteCodeBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NoteCodeBox.Location = new System.Drawing.Point(0, 73);
            this.NoteCodeBox.Name = "NoteCodeBox";
            this.NoteCodeBox.Size = new System.Drawing.Size(498, 22);
            this.NoteCodeBox.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 80;
            this.label12.Text = "Примечание";
            // 
            // EventCodeBox
            // 
            this.EventCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventCodeBox.Location = new System.Drawing.Point(0, 24);
            this.EventCodeBox.Name = "EventCodeBox";
            this.EventCodeBox.Size = new System.Drawing.Size(495, 22);
            this.EventCodeBox.TabIndex = 76;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 79;
            this.label11.Text = "Событие";
            // 
            // TimeList
            // 
            this.TimeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeList.FormattingEnabled = true;
            this.TimeList.ItemHeight = 16;
            this.TimeList.Location = new System.Drawing.Point(0, 163);
            this.TimeList.Name = "TimeList";
            this.TimeList.ScrollAlwaysVisible = true;
            this.TimeList.Size = new System.Drawing.Size(498, 788);
            this.TimeList.TabIndex = 70;
            this.TimeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TimeList_MouseDoubleClick);
            // 
            // AddConfession
            // 
            this.AddConfession.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AddConfession.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddConfession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddConfession.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddConfession.Location = new System.Drawing.Point(74, 0);
            this.AddConfession.Name = "AddConfession";
            this.AddConfession.Size = new System.Drawing.Size(132, 68);
            this.AddConfession.TabIndex = 84;
            this.AddConfession.Text = "Признание";
            this.AddConfession.UseVisualStyleBackColor = false;
            this.AddConfession.Click += new System.EventHandler(this.AddConfession_Click);
            // 
            // TimeListPanel
            // 
            this.TimeListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeListPanel.Controls.Add(this.TimeList);
            this.TimeListPanel.Controls.Add(this.panel1);
            this.TimeListPanel.Controls.Add(this.panel2);
            this.TimeListPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TimeListPanel.Location = new System.Drawing.Point(1200, 0);
            this.TimeListPanel.Name = "TimeListPanel";
            this.TimeListPanel.Size = new System.Drawing.Size(500, 1000);
            this.TimeListPanel.TabIndex = 83;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddConfession);
            this.panel1.Controls.Add(this.AddTimeCode);
            this.panel1.Controls.Add(this.RenameTimeCode);
            this.panel1.Controls.Add(this.DeleteTimeCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 68);
            this.panel1.TabIndex = 85;
            // 
            // AddTimeCode
            // 
            this.AddTimeCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AddTimeCode.BackgroundImage = global::ADAL_Video.Properties.Resources.add_time_40;
            this.AddTimeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddTimeCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddTimeCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTimeCode.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTimeCode.Location = new System.Drawing.Point(206, 0);
            this.AddTimeCode.Name = "AddTimeCode";
            this.AddTimeCode.Size = new System.Drawing.Size(106, 68);
            this.AddTimeCode.TabIndex = 71;
            this.AddTimeCode.UseVisualStyleBackColor = false;
            this.AddTimeCode.Click += new System.EventHandler(this.AddTimeCode_Click);
            // 
            // RenameTimeCode
            // 
            this.RenameTimeCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.RenameTimeCode.BackgroundImage = global::ADAL_Video.Properties.Resources.rename_48;
            this.RenameTimeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RenameTimeCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.RenameTimeCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RenameTimeCode.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenameTimeCode.Location = new System.Drawing.Point(312, 0);
            this.RenameTimeCode.Name = "RenameTimeCode";
            this.RenameTimeCode.Size = new System.Drawing.Size(99, 68);
            this.RenameTimeCode.TabIndex = 83;
            this.RenameTimeCode.UseVisualStyleBackColor = false;
            this.RenameTimeCode.Click += new System.EventHandler(this.RenameTimeCode_Click);
            // 
            // DeleteTimeCode
            // 
            this.DeleteTimeCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DeleteTimeCode.BackgroundImage = global::ADAL_Video.Properties.Resources.remove_48;
            this.DeleteTimeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteTimeCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteTimeCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTimeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteTimeCode.Location = new System.Drawing.Point(411, 0);
            this.DeleteTimeCode.Name = "DeleteTimeCode";
            this.DeleteTimeCode.Size = new System.Drawing.Size(87, 68);
            this.DeleteTimeCode.TabIndex = 72;
            this.DeleteTimeCode.UseVisualStyleBackColor = false;
            this.DeleteTimeCode.Click += new System.EventHandler(this.DeleteTimeCode_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.NoteCodeBox);
            this.panel2.Controls.Add(this.EventCodeBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 95);
            this.panel2.TabIndex = 85;
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 0);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(921, 1000);
            this.panelDesktopPane.TabIndex = 91;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1700, 1000);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.TimeListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1700, 1000);
            this.MinimumSize = new System.Drawing.Size(1700, 1000);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АДАЛ-Видео";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUSB)).EndInit();
            this.TimeListPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxUSB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переместитьToolStripMenuItem;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button AddTimeCode;
        private System.Windows.Forms.TextBox NoteCodeBox;
        private System.Windows.Forms.Button DeleteTimeCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox EventCodeBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox TimeList;
        private System.Windows.Forms.Button RenameTimeCode;
        private System.Windows.Forms.Button AddConfession;
        private System.Windows.Forms.Panel TimeListPanel;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button HideTimeList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMenu;
    }
}

