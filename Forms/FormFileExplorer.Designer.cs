namespace ADAL_Video.Forms
{
    partial class FormFileExplorer
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
            this.FileExplorerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MoveSelectedFiles = new System.Windows.Forms.Button();
            this.DeleteSelectedFiles = new System.Windows.Forms.Button();
            this.CopySelectedFiles = new System.Windows.Forms.Button();
            this.dirBtn = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переместитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExplorerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileExplorerPanel
            // 
            this.FileExplorerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileExplorerPanel.Controls.Add(this.pictureBox1);
            this.FileExplorerPanel.Controls.Add(this.SearchBox);
            this.FileExplorerPanel.Controls.Add(this.FileList);
            this.FileExplorerPanel.Controls.Add(this.MoveSelectedFiles);
            this.FileExplorerPanel.Controls.Add(this.DeleteSelectedFiles);
            this.FileExplorerPanel.Controls.Add(this.CopySelectedFiles);
            this.FileExplorerPanel.Controls.Add(this.dirBtn);
            this.FileExplorerPanel.Controls.Add(this.pathBox);
            this.FileExplorerPanel.Controls.Add(this.label5);
            this.FileExplorerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileExplorerPanel.Location = new System.Drawing.Point(0, 0);
            this.FileExplorerPanel.Name = "FileExplorerPanel";
            this.FileExplorerPanel.Size = new System.Drawing.Size(1408, 885);
            this.FileExplorerPanel.TabIndex = 69;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ADAL_Video.Properties.Resources.search;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // SearchBox
            // 
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Location = new System.Drawing.Point(34, 49);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(380, 22);
            this.SearchBox.TabIndex = 64;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // FileList
            // 
            this.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.FileList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileList.FullRowSelect = true;
            this.FileList.GridLines = true;
            this.FileList.HideSelection = false;
            this.FileList.LabelEdit = true;
            this.FileList.Location = new System.Drawing.Point(0, 143);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(1406, 740);
            this.FileList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.FileList.TabIndex = 63;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.FileList_AfterLabelEdit);
            this.FileList.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.FileList_BeforeLabelEdit);
            this.FileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FileList_ColumnClick);
            this.FileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 287;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата";
            this.columnHeader3.Width = 148;
            // 
            // MoveSelectedFiles
            // 
            this.MoveSelectedFiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.MoveSelectedFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveSelectedFiles.Font = new System.Drawing.Font("Nirmala UI", 8F);
            this.MoveSelectedFiles.Location = new System.Drawing.Point(631, 45);
            this.MoveSelectedFiles.Name = "MoveSelectedFiles";
            this.MoveSelectedFiles.Size = new System.Drawing.Size(120, 30);
            this.MoveSelectedFiles.TabIndex = 67;
            this.MoveSelectedFiles.Text = "Переместить";
            this.MoveSelectedFiles.UseVisualStyleBackColor = false;
            this.MoveSelectedFiles.Click += new System.EventHandler(this.MoveSelectedFiles_Click);
            // 
            // DeleteSelectedFiles
            // 
            this.DeleteSelectedFiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DeleteSelectedFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSelectedFiles.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedFiles.Location = new System.Drawing.Point(420, 45);
            this.DeleteSelectedFiles.Name = "DeleteSelectedFiles";
            this.DeleteSelectedFiles.Size = new System.Drawing.Size(92, 30);
            this.DeleteSelectedFiles.TabIndex = 65;
            this.DeleteSelectedFiles.Text = "Удалить";
            this.DeleteSelectedFiles.UseVisualStyleBackColor = false;
            this.DeleteSelectedFiles.Click += new System.EventHandler(this.DeleteSelectedFiles_Click);
            // 
            // CopySelectedFiles
            // 
            this.CopySelectedFiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CopySelectedFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopySelectedFiles.Font = new System.Drawing.Font("Nirmala UI", 8F);
            this.CopySelectedFiles.Location = new System.Drawing.Point(518, 44);
            this.CopySelectedFiles.Name = "CopySelectedFiles";
            this.CopySelectedFiles.Size = new System.Drawing.Size(106, 30);
            this.CopySelectedFiles.TabIndex = 66;
            this.CopySelectedFiles.Text = "Копировать";
            this.CopySelectedFiles.UseVisualStyleBackColor = false;
            this.CopySelectedFiles.Click += new System.EventHandler(this.CopySelectedFiles_Click);
            // 
            // dirBtn
            // 
            this.dirBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.dirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dirBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dirBtn.Location = new System.Drawing.Point(531, 4);
            this.dirBtn.Name = "dirBtn";
            this.dirBtn.Size = new System.Drawing.Size(93, 29);
            this.dirBtn.TabIndex = 9;
            this.dirBtn.Text = "Обзор...";
            this.dirBtn.UseVisualStyleBackColor = false;
            this.dirBtn.Click += new System.EventHandler(this.DirBtn_Click);
            // 
            // pathBox
            // 
            this.pathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathBox.Location = new System.Drawing.Point(121, 8);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(391, 22);
            this.pathBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Рабочая папка:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переименоватьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.переместитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // переместитьToolStripMenuItem
            // 
            this.переместитьToolStripMenuItem.Name = "переместитьToolStripMenuItem";
            this.переместитьToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.переместитьToolStripMenuItem.Text = "Переместить";
            // 
            // FormFileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 885);
            this.Controls.Add(this.FileExplorerPanel);
            this.Name = "FormFileExplorer";
            this.Text = "Файловый Менеджер";
            this.Load += new System.EventHandler(this.FormFileExplorer_Load);
            this.FileExplorerPanel.ResumeLayout(false);
            this.FileExplorerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FileExplorerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button MoveSelectedFiles;
        private System.Windows.Forms.Button DeleteSelectedFiles;
        private System.Windows.Forms.Button CopySelectedFiles;
        private System.Windows.Forms.Button dirBtn;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переместитьToolStripMenuItem;
    }
}