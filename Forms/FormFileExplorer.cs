using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace ADAL_Video.Forms
{
    public partial class FormFileExplorer : Form
    {
        string path;        // путь для сохранения аудио и видео
        private PlayState currentState;
        private ListViewColumnSorter lvwColumnSorter;
        public FormFileExplorer()
        {
            InitializeComponent();
        }
        private void UpdateFilelist()
        {
            FileList.Items.Clear();
            Console.WriteLine(@pathBox.Text);
            DirectoryInfo nodeDirInfo = new DirectoryInfo(@pathBox.Text);
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, "Папка"),
                        new ListViewItem.ListViewSubItem(item,  dir.LastAccessTime.ToShortDateString())
                    };
                item.SubItems.AddRange(subItems);
                FileList.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                if (file.Extension == ".wma")
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, "Аудио"),
                        new ListViewItem.ListViewSubItem(item, file.CreationTime.ToString())
                    };
                }
                else if (file.Extension == ".avi" || file.Extension == ".wmv")
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, "Видео"),
                        new ListViewItem.ListViewSubItem(item, file.CreationTime.ToString())
                    };
                }
                else
                {
                    item = new ListViewItem();
                    subItems = new ListViewItem.ListViewSubItem[] { };
                }
                item.SubItems.AddRange(subItems);
                FileList.Items.Add(item);
            }
         //   FileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void FileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            this.FileList.Sort();
        }
        private void FileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderList = (ListView)sender;
            var clickedItem = senderList.HitTest(e.Location).Item;
            if (clickedItem != null)
            {
                string filename = Path.Combine(pathBox.Text, clickedItem.Text);
                if (currentState == PlayState.Stopped || currentState == PlayState.Init)
                {
                    try
                    {
                        new FormPlay();
                        //PlayVideo(filename);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else if (currentState == PlayState.PausedRunning || currentState == PlayState.Running)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    Form frm = Application.OpenForms["Form2"];
                    if (frm != null)
                    {
                        frm.Location = new Point(0, 0);
                        frm.Size = new Size(285, 490);
                    }
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите переключить видео?", "Остановка процесса", buttons);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                       // StopVideo();
                        if (frm != null)
                            frm.Close();
                        try
                        {
                            //PlayVideo(filename);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }
        private string GetListViewItemText(int index)
        {
            if (FileList.Items.Count > index)
                return FileList.Items[index].Text;
            else
                return String.Empty;
        }
        private void FileList_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            IntPtr editWnd = SendMessage(FileList.Handle, LVM_GETEDITCONTROL, 0, IntPtr.Zero);
            int textLen = Path.GetFileNameWithoutExtension(FileList.Items[e.Item].Text).Length;
            SendMessage(editWnd, EM_SETSEL, 0, (IntPtr)textLen);
        }
        public const int EM_SETSEL = 0xB1;
        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETEDITCONTROL = (LVM_FIRST + 24);
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int len, IntPtr order);
        private void FileList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (currentState == PlayState.Stopped || currentState == PlayState.Init)
            {
                try
                {
                    string itemText = GetListViewItemText(e.Item);
                    string sourceDirName = Path.Combine(pathBox.Text, itemText);
                    string destFileName = e.Label;
                    Console.WriteLine(Path.GetExtension(itemText));
                    if (destFileName == null || destFileName == Path.GetExtension(itemText) || destFileName == itemText || destFileName == String.Empty)
                        throw new ArgumentNullException("Invalid");
                    if (Path.GetExtension(destFileName) != Path.GetExtension(itemText))
                        destFileName += Path.GetExtension(sourceDirName);

                    string destDirName = Path.Combine(pathBox.Text, destFileName);
                    Directory.Move(sourceDirName, destDirName);
                    FileList.Items[e.Item].Text = destFileName;
                }
                catch (Exception ex)
                {
                    e.CancelEdit = true;
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text != "")
            {
                for (int i = FileList.Items.Count - 1; i >= 0; i--)
                {
                    var item = FileList.Items[i];
                    if (!item.Text.ToLower().Contains(SearchBox.Text.ToLower()))
                        FileList.Items.Remove(item);
                }
            }
            else
            {
                UpdateFilelist();
            }
        }
        private void DeleteSelectedFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FileList.SelectedItems)
                File.Delete(Path.Combine(pathBox.Text, item.Text));
            UpdateFilelist();
        }
        private void CopySelectedFiles_Click(object sender, EventArgs e)
        {
            CopyMoveFiles(true);
        }
        private void MoveSelectedFiles_Click(object sender, EventArgs e)
        {
            CopyMoveFiles(false);
        }
        private void HideFileExplorer_Click(object sender, EventArgs e)
        {
            if (FileExplorerPanel.Visible == true)
            {
                FileExplorerPanel.Visible = false;
                this.MinimumSize = new Size(500, 1000);
                this.Size = new Size(500, 1000);
            }
            else
            {
                FileExplorerPanel.Visible = true;
                this.MinimumSize = new Size(1000, 1000);
                this.Size = new Size(1000, 1000);
            }
        }
        private void DirBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = folderBrowserDialog1.SelectedPath;
                path = folderBrowserDialog1.SelectedPath;
                UpdateFilelist();
            }
        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FileList.SelectedItems.Count == 0)
                e.Cancel = true;
        }
        private void CopyMoveFiles(bool saveOriginal)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                string CopyPath = folderBrowserDialog2.SelectedPath;
                foreach (ListViewItem item in FileList.SelectedItems)
                {
                    string fileName = item.Text;
                    string filePath = Path.Combine(pathBox.Text, fileName);
                    string destFile = Path.Combine(CopyPath, fileName);
                    if (File.Exists(destFile))
                    {
                        MessageBox.Show(fileName + " уже существует в указанной папке!");
                    }
                    else
                    {
                        if (Path.HasExtension(filePath))
                        {
                            if (saveOriginal)
                                File.Copy(filePath, destFile);
                            else
                                File.Move(filePath, destFile);
                        }
                    }
                }
            }
            UpdateFilelist();
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Переименовать")
            {
                FileList.SelectedItems[0].BeginEdit();
            }
            else if (e.ClickedItem.Text == "Удалить")
            {
                foreach (ListViewItem item in FileList.SelectedItems)
                    File.Delete(Path.Combine(pathBox.Text, item.Text));
                UpdateFilelist();
            }
            else if (e.ClickedItem.Text == "Копировать")
            {
                CopyMoveFiles(true);
            }
            else if (e.ClickedItem.Text == "Переместить")
            {
                CopyMoveFiles(false);
            }
        }

        private void FormFileExplorer_Load(object sender, EventArgs e)
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ADAL-Video");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Console.WriteLine("Payh:{0}",path);
            pathBox.Text = path;
            UpdateFilelist();
            lvwColumnSorter = new ListViewColumnSorter();
            this.FileList.ListViewItemSorter = lvwColumnSorter;

            lvwColumnSorter.SortColumn = 2;
            lvwColumnSorter.Order = SortOrder.Descending;
            this.FileList.Sort();
        }
    }
}
