using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;


namespace ADAL_Video.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

        }
        private IGraphBuilder graphAudio, graphVideo1, graphVideo2, graphPlay, graphPlay2 = null;
        static void CheckHR(int hr, string msg)
        {
            if (hr < 0)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(msg, w);
                }
                MessageBox.Show("Ошибка графа:" + msg + "!  " + "Код ошибки: 0x" + hr.ToString("X"));
                DsError.ThrowExceptionForHR(hr);
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Camera1 = videoBox1.SelectedIndex;
            Properties.Settings.Default.Camera2 = videoBox2.SelectedIndex;
            if (CamSet1.SelectedItem!=null)
                Properties.Settings.Default.Resolution1 = (int)CamSet1.SelectedItem;
            if (CamSet2.SelectedItem != null)
                Properties.Settings.Default.Resolution2 = (int)CamSet2.SelectedItem;
            Properties.Settings.Default.Microphone = audioBox.SelectedIndex;
            Properties.Settings.Default.AudioOn = recAudio.Checked;
            Properties.Settings.Default.format = FormatBox.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            
        }
        public static IBaseFilter CreateFilterByNum(int id, Guid category)
        {
            int hr;
            DsDevice[] devices = DsDevice.GetDevicesOfCat(category);
            DsDevice dev = devices[id];
            IBaseFilter filter = null;
            IBindCtx bindCtx = null;
            try
            {
                hr = CreateBindCtx(0, out bindCtx);
                DsError.ThrowExceptionForHR(hr);
                Guid guid = typeof(IBaseFilter).GUID;
                dev.Mon.BindToObject(bindCtx, null, ref guid, out object obj);
                filter = (IBaseFilter)obj;
            }
            finally
            {
                if (bindCtx != null) Marshal.ReleaseComObject(bindCtx);
            }
            return filter;
        }
        [DllImport("ole32.dll")]
        public static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);

        private void FormSettings_Load(object sender, EventArgs e)
        {
            
            FormatBox.Items.Add(".wmv");
            FormatBox.Items.Add(".avi");
            FormatBox.SelectedIndex = 0;
            DsDevice[] VcaptureDevices;
            VcaptureDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            for (int idx = 0; idx < VcaptureDevices.Length; idx++)
            {
                videoBox1.Items.Add(VcaptureDevices[idx].Name);
                videoBox2.Items.Add(VcaptureDevices[idx].Name);
            }
            DsDevice[] captureDevices;
            captureDevices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);
            for (int idx = 0; idx < captureDevices.Length; idx++)
            {
                audioBox.Items.Add(captureDevices[idx].Name);
            }
            if (captureDevices.Length >= 1)
                audioBox.SelectedIndex = captureDevices.Length - 1;


            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTip1.SetToolTip(this.ClearWindow, "Очистить окно настроек");
            Console.WriteLine(Properties.Settings.Default.Camera1);
            videoBox1.SelectedIndex = Properties.Settings.Default.Camera1;
            videoBox2.SelectedIndex = Properties.Settings.Default.Camera2;
            audioBox.SelectedIndex = Properties.Settings.Default.Microphone;
            CamSet1.SelectedItem = Properties.Settings.Default.Resolution1;
            CamSet2.SelectedItem = Properties.Settings.Default.Resolution2;
            recAudio.Checked = Properties.Settings.Default.AudioOn;
          //  videoBox2.Enabled = false;

          //  CamSet2.Enabled = false;

        }

        private void VideoConfig(int selCamID, int camID)
        {
            int hr;
            graphVideo1 = (IGraphBuilder)new FilterGraph();
            ICaptureGraphBuilder2 pBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            hr = pBuilder.SetFiltergraph(graphVideo1);
            CheckHR(hr, "Can't SetFiltergraph");
            if (selCamID != -1)
            {
                IBaseFilter WebCam = CreateFilterByNum(selCamID, FilterCategory.VideoInputDevice);
                hr = graphVideo1.AddFilter(WebCam, "Video Capture");
                CheckHR(hr, "Не удалось добавить камеру в граф");
                pBuilder.FindInterface(PinCategory.Capture, MediaType.Video, WebCam, typeof(IAMStreamConfig).GUID, out object comObj);
                IAMStreamConfig iamsc = comObj as IAMStreamConfig;
                hr = iamsc.GetNumberOfCapabilities(out int CapCount, out int CapSize);
                CheckHR(hr, "Can't NumberOfCapabilities");
                IntPtr pSC = Marshal.AllocHGlobal(CapSize);
                List<int> resols = new List<int>();
                for (int i = 0; i < CapCount; i++)
                {
                    hr = iamsc.GetStreamCaps(i, out AMMediaType searchmedia, pSC);
                    CheckHR(hr, "Can't GetStreamCaps");
                    VideoInfoHeader v = new VideoInfoHeader();
                    Marshal.PtrToStructure(searchmedia.formatPtr, v);
                    int h = v.BmiHeader.Height; // переменная для отображения
                    int w = v.BmiHeader.Width;
                    //double fps = 10000000 / v.AvgTimePerFrame;
                    Console.WriteLine(searchmedia.subType.ToString() + "  " + h.ToString() + "x" + w.ToString());
                    if (resols.IndexOf(h) == -1)
                        resols.Add(h);
                }
                resols.Distinct().ToList();
                resols.Sort();
                foreach (int h1 in resols)
                {
                    if (camID == 1)
                    {
                        if (h1 <= 720 && h1 >= 240 && h1 % 10 == 0 && h1 % 100 != 0)
                            CamSet1.Items.Add(h1);
                    }
                    if (camID == 2)
                    {
                        if (h1 <= 720 && h1 >= 240 && h1 % 10 == 0 && h1 % 100 != 0)
                            CamSet2.Items.Add(h1);
                    }
                }
            }
        }
        private void ClearWindow_Click(object sender, EventArgs e)
        {
            videoBox1.SelectedIndex = -1;
            videoBox1.SelectedItem = "";
            videoBox2.SelectedIndex = -1;
            videoBox2.SelectedItem = "";
            videoBox2.Enabled = false;
            CamSet2.Enabled = false;
            CamSet1.SelectedIndex = -1;
            CamSet1.SelectedItem = "";
            CamSet2.SelectedIndex = -1;
            CamSet2.SelectedItem = "";
            recAudio.Checked = false;
        }
        private void VideoBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int camID1 = 1;
            int videoCam1 = this.videoBox1.SelectedIndex;
            CamSet1.Items.Clear();
            if (this.videoBox2.SelectedIndex == videoCam1)
            {
                //videoBox1.SelectedIndex = -1;
                //videoBox1.SelectedItem = "";
            }
            else
            {
                VideoConfig(videoCam1, camID1);
                if (videoCam1 != -1 )
                {
                 //   videoBox2.Enabled = true;
                    CamSet2.Enabled = true;
                }
                else
                {
                    CamSet1.Text = "";
                  //  videoBox2.Enabled = false;
                   // CamSet2.Enabled = false;
                }
            }
        }
        private void VideoBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int camID2 = 2;
            int videoCam2 = this.videoBox2.SelectedIndex;
            CamSet2.Items.Clear();
            if (this.videoBox1.SelectedIndex == videoCam2)
            {
                videoBox2.SelectedIndex = -1;
                videoBox2.SelectedItem = "";
            }
            else
            {
                VideoConfig(videoCam2, camID2);
            }
        }

    }
}
