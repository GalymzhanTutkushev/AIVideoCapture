using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading.Tasks;
using System.Management;
using System.Linq;

namespace ADAL_Video
{
    internal enum PlayState  { Stopped, Preview, Capture, PausedCapture, PausedRunning, Running,  Init };
    public partial class Form1 : Form
    {
        internal static class UsbNotification
        {
            public const int DbtDevicearrival = 0x8000;             // system detected a new device        
            public const int DbtDeviceremovecomplete = 0x8004;      // device is gone      
            public const int WmDevicechange = 0x0219;               // device change event      
            private const int DbtDevtypDeviceinterface = 5;
            private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
            private static IntPtr notificationHandle;
            /// <param name="windowHandle">Handle to the window receiving notifications.</param>
            public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
            {
                DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
                {
                    DeviceType = DbtDevtypDeviceinterface,
                    Reserved = 0,
                    ClassGuid = GuidDevinterfaceUSBDevice,
                    Name = 0
                };
                dbi.Size = Marshal.SizeOf(dbi);
                IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
                Marshal.StructureToPtr(dbi, buffer, true);
                notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
            }
            public static void UnregisterUsbDeviceNotification()
            {
                UnregisterDeviceNotification(notificationHandle);
            }
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);
            [DllImport("user32.dll")]
            private static extern bool UnregisterDeviceNotification(IntPtr handle);
            [StructLayout(LayoutKind.Sequential)]
            private struct DevBroadcastDeviceinterface
            {
                internal int Size;
                internal int DeviceType;
                internal int Reserved;
                internal Guid ClassGuid;
                internal short Name;
            }
        }

        List<TimeModel> times = new List<TimeModel>();
        private Button currentButton;
       //private Random random;
        private Form activeForm;
        string tableName;
        public Form1()
        {
            InitializeComponent();
            
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
            //random = new Random();
           // btnCloseChildForm.Visible = false;
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private PlayState currentState;
        private IMediaControl  mediacontroPlay,mediaControlPlay2 = null;
        private IMediaPosition mediaPosition,mediaPosition2 = null;
        string USBDev;      //Статус подключения USB

        #region UserInterfaceMethods
        [DllImport("Setupapi.dll", EntryPoint = "InstallHinfSection", CallingConvention = CallingConvention.StdCall)]
        public static extern void InstallHinfSection(
        [In] IntPtr hwnd,
        [In] IntPtr ModuleHandle,
        [In, MarshalAs(UnmanagedType.LPWStr)] string CmdLineBuffer,
        int nCmdShow);
        private void GetDriver()
        {
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher("Select * from Win32_PnPSignedDriver");

            ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (ManagementObject obj in objCollection)
            {
             if(obj["DeviceName"] != null)
                {
                    if (obj["DeviceName"].ToString() == "USB Video Device" || obj["DeviceName"].ToString() == "USB Composite Device" 
                        || obj["DeviceName"].ToString() == "Imaging devices" ||true)
                    {
                        string info = String.Format("Device='{0}',Manufacturer='{1}',DriverVersion='{2}' ", obj["DeviceName"], obj["Manufacturer"], obj["DriverVersion"]);
                        Console.WriteLine(info);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            Log(info, w);
                        }
                    }
                }
                
            }
        }
        private async void ShowUSB(string stat)
        {
            if (stat == "подключено")
                pictureBoxUSB.Image = Properties.Resources.usb_connected;
            if (stat == "отключено")
                pictureBoxUSB.Image = Properties.Resources.usb_disconnected;

            pictureBoxUSB.Visible = true;
            await Task.Delay(1000);
            pictureBoxUSB.Visible = false;
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
        string path;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetDriver();
            currentState = PlayState.Init;
            TimeListPanel.Visible = false;
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ADAL-Video");
            Properties.Settings.Default.path = path;
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
            toolTip1.SetToolTip(this.AddConfession, "Быстрая метка о признании");
            

            TimeListPanel.Enabled = false;
           
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        {
                            USBDev = "отключено";
                            break;
                        }
                    case UsbNotification.DbtDevicearrival:
                        {
                            USBDev = "подключено";
                            break;
                        }
                }
                //DsDevice[] VcaptureDevices;
                //DsDevice[] captureDevices;
                //VcaptureDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                //captureDevices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);

                //if (videoBox1.Items.Count != VcaptureDevices.Length)
                //{
                //    ShowUSB(USBDev);
                //    videoBox1.Items.Clear();
                //    videoBox2.Items.Clear();
                //    for (int idx = 0; idx < VcaptureDevices.Length; idx++)
                //    {
                //        videoBox1.Items.Add(VcaptureDevices[idx].Name);
                //        videoBox2.Items.Add(VcaptureDevices[idx].Name);
                //    }
                //    videoBox1.Text = "";
                //    videoBox2.Text = "";
                //    CamSet1.Items.Clear();
                //    CamSet2.Items.Clear();
                //    CamSet1.Text = "";
                //    CamSet2.Text = "";
                //    PreviewBtn.Enabled = false;
                //}
                //if (audioBox.Items.Count != captureDevices.Length)
                //{
                //    ShowUSB(USBDev);
                //    audioBox.Items.Clear();
                //    for (int idx = 0; idx < captureDevices.Length; idx++)
                //    {
                //        audioBox.Items.Add(captureDevices[idx].Name);
                //    }
                //}
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)   
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        break;
                    }
                case Keys.Left:
                    {
                       
                        break;
                    }
                case Keys.Right:
                    {
                       
                        break;
                    }

            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                panelLogo.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                panelLogo.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
        private Color SelectThemeColor(int index)
        {
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void ActivateButton(object btnSender, int index)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor(index);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender, int index)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender,index);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
           
            lblTitle.Text = childForm.Text;
        }
        
        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender,7);
            TimeListPanel.Visible = false;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCapture(), sender,2);
            TimeListPanel.Visible = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPlay(), sender,3);
            TimeListPanel.Visible = true;
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormFileExplorer(), sender,4);
            TimeListPanel.Visible = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
          
            try
            {
                Help.ShowHelp(this, @"help\main.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.TimeList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                TimeModel t = (TimeModel)TimeList.SelectedItem;
                if (mediaPosition == null)
                    return;
                int timePos = t.Time;
                mediaPosition.get_Duration(out double pLength);
                if (timePos < 0 || timePos > pLength)
                    return;
                mediaPosition.put_CurrentPosition(timePos);
                mediaPosition2.put_CurrentPosition(timePos);
            }
        }
        private void AddTimeCode_Click(object sender, EventArgs e)
        {
            RenameSelectedTimeCode("");
        }
        private void DeleteTimeCode_Click(object sender, EventArgs e)
        {
            TimeModel t = (TimeModel)TimeList.SelectedItem;
            SqliteDataAccess.DeleteTime(t, tableName);
            LoadTimeList(tableName);
        }
        private void HideTimeList_Click(object sender, EventArgs e)
        {
            if (TimeListPanel.Width != 0)
            {
                TimeListPanel.Width = 0;
                panelDesktopPane.Width += 500;
            }
            else
            {
                TimeListPanel.Width = 500;
                panelDesktopPane.Width -= 500;

            }
        }
        private void RenameTimeCode_Click(object sender, EventArgs e)
        {
            try
            {
                TimeModel t = (TimeModel)TimeList.SelectedItem;
                t.Name = EventCodeBox.Text;
                t.Note = NoteCodeBox.Text;
                SqliteDataAccess.RenameTime(t, tableName);
                EventCodeBox.Text = "";
                NoteCodeBox.Text = "";
                LoadTimeList(tableName);
            }
            catch
            {
                Console.WriteLine("Не удалось преобразовать тип");
                return;
            }
        }
        private void AddConfession_Click(object sender, EventArgs e)
        {
            RenameSelectedTimeCode("Признание");
        }
        private void RenameSelectedTimeCode(string name)
        {
            TimeModel t = new TimeModel();
            try
            {
                if (currentState == PlayState.Capture)
                {
                    //TimeSpan timeDifference = DateTime.Now - VideoStart;
                    //int unixEpochTime = Convert.ToInt32(timeDifference.TotalSeconds);
                    //t.Time = unixEpochTime;
                }
                else if (currentState == PlayState.Running || currentState == PlayState.PausedRunning)
                {
                    mediaPosition.get_CurrentPosition(out double pos);
                    t.Time = (int)pos;
                }
                if (name == "Признание")
                    t.Name = name;
                else
                    t.Name = EventCodeBox.Text;
                t.Note = NoteCodeBox.Text;
                SqliteDataAccess.SaveTime(t, tableName);
                EventCodeBox.Text = "";
                NoteCodeBox.Text = "";
                LoadTimeList(tableName);
            }
            catch
            {
                Console.WriteLine("Не удалось преобразовать тип");
                return;
            }
        }
        private void LoadTimeList(string tab)
        {
            times = SqliteDataAccess.LoadTime(tab);
            WireUpTimeList();
        }
        private void WireUpTimeList()
        {
            TimeList.DataSource = null;
            TimeList.DataSource = times;
            TimeList.DisplayMember = "FullName";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            Form frm = Application.OpenForms["Form2"];
            if (frm != null)
            {
                frm.Location = new Point(0, 0);
                frm.Size = new Size(285, 490);
            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход из программы", buttons);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = Application.OpenForms["Form2"];
            if (frm != null)
                frm.Close();

            Application.Exit();
            Environment.Exit(1);
        }
        #endregion
    }
}