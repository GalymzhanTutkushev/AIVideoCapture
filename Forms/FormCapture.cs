using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DirectShowLib;
using WindowsMediaLib;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace ADAL_Video.Forms
{
    public partial class FormCapture : Form
    {
        string path;
        public FormCapture()
        {
            InitializeComponent();

        }
#if DEBUG
        private DsROTEntry rot = null;
#endif
        private IMediaControl mediaControlA1, mediaControlV1, mediaControlV2, mediaControlPlay, mediaControlPlay2 = null;
        private IGraphBuilder graphAudio, graphVideo1, graphVideo2, graphPlay, graphPlay2 = null;
        int TotalSec = 0;
        int TotalSec2 = 0;
        int hh, mm, ss;    // время записи
        int h, m, s;        //время воспроизведения
        private PlayState currentState;

        DateTime VideoStart;
        #region GraphBuilders
        static void BuildAudioGraph(IGraphBuilder pGraph, string dstFile3, int audioIN)
        {
            int hr;
            ICaptureGraphBuilder2 pBuilderA = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            hr = pBuilderA.SetFiltergraph(pGraph);
            CheckHR(hr, "Не удается передать граф построителю графов");
            IBaseFilter pRealtekRAudio3 = CreateFilterByNum(audioIN, FilterCategory.AudioInputDevice);
            hr = pGraph.AddFilter(pRealtekRAudio3, "Audio Capture");
            CheckHR(hr, "Не удалось добавить микрофон в граф");
            IPin pinAudOut3 = DsFindPin.ByCategory(pRealtekRAudio3, PinCategory.Capture, 0);
            Guid CLSID_MicrosoftMPEG2AudioEncoder = new Guid("{ACD453BC-C58A-44D1-BBF5-BFB325BE2D78}"); //msmpeg2enc.dll
            pBuilderA.FindInterface(PinCategory.Capture, MediaType.Audio, pRealtekRAudio3, typeof(IAMStreamConfig).GUID, out object audObj);
            IAMStreamConfig iamscAud = audObj as IAMStreamConfig;
            AMMediaType Amediatype = new AMMediaType();
            hr = iamscAud.GetNumberOfCapabilities(out int ACapCount, out int ACapSize);
            CheckHR(hr, "Не удалось получить количество настроек микрофона");
            IntPtr ApSC = Marshal.AllocHGlobal(ACapSize);
            int freq, nc, nb;
            for (int i = 0; i < ACapCount; i++)
            {
                hr = iamscAud.GetStreamCaps(i, out AMMediaType searchAmedia, ApSC);
                CheckHR(hr, "Не удалось получить список настроек микрофона");
                WaveFormatEx va = new WaveFormatEx();
                Marshal.PtrToStructure(searchAmedia.formatPtr, va);
                freq = va.nSamplesPerSec;
                nc = va.nChannels;
                nb = va.wBitsPerSample;
                if (freq == 22050 && nc == 1 && nb == 16)  // Минимально: частота 22 050 Гц, количество каналов 1, битность 16
                    Amediatype = searchAmedia;
            }
            hr = iamscAud.SetFormat(Amediatype);
            CheckHR(hr, "Не удалось установить настройки микрофона");

            //add File writer
            IBaseFilter pFilewriter3 = (IBaseFilter)new FileWriter();
            hr = pGraph.AddFilter(pFilewriter3, "File writer");
            CheckHR(hr, "Не удалось добавить записыватель аудиофайла в граф");
            //set destination filename
            IFileSinkFilter pFilewriter3_sink = pFilewriter3 as IFileSinkFilter;
            if (pFilewriter3_sink == null)
                CheckHR(unchecked((int)0x80004002), "Can't get IFileSinkFilter");
            hr = pFilewriter3_sink.SetFileName(dstFile3, null);
            CheckHR(hr, "Не удалось установить имя аудиофайла");
            IBaseFilter pMicrosoftMPEG2AudioEncoder = (IBaseFilter)Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID_MicrosoftMPEG2AudioEncoder));
            hr = pGraph.AddFilter(pMicrosoftMPEG2AudioEncoder, "Microsoft MPEG-2 Audio Encoder");
            CheckHR(hr, "Не удалось добавить Microsoft MPEG-2 Audio Encoder в граф");
            hr = pGraph.ConnectDirect(pinAudOut3, GetPin(pMicrosoftMPEG2AudioEncoder, "Input0"), null);
            CheckHR(hr, "Не удалось соединить Микрофон и Microsoft MPEG-2 Audio Encoder");
            hr = pGraph.ConnectDirect(GetPin(pMicrosoftMPEG2AudioEncoder, "Output"), GetPin(pFilewriter3, "in"), null);
            CheckHR(hr, "Не удалось соединить Microsoft MPEG-2 Audio Encoder и записыватель аудиофайла");
        }
        void BuildVideoGraph(IGraphBuilder pGraph, string dstFile1, int audioIN, int videoIN1, int videoSet1, bool capture)
        {
            int hr;
            ICaptureGraphBuilder2 pBuilderV = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            hr = pBuilderV.SetFiltergraph(pGraph);
            CheckHR(hr, "Не удается передать граф построителю графов");

            IBaseFilter pVGAWebCam = CreateFilterByNum(videoIN1, FilterCategory.VideoInputDevice);
            hr = pGraph.AddFilter(pVGAWebCam, "Video Capture");
            CheckHR(hr, "Не удалось добавить камеру в граф");
            IBaseFilter pRealtekRAudio = CreateFilterByNum(audioIN, FilterCategory.AudioInputDevice);
            hr = pGraph.AddFilter(pRealtekRAudio, "Audio Capture");
            CheckHR(hr, "Не удалось добавить микрофон в граф");
            IPin pinCaptOut = DsFindPin.ByCategory(pVGAWebCam, PinCategory.Capture, 0);
            // IPin pinAudOut = DsFindPin.ByCategory(pRealtekRAudio, PinCategory.Capture, 0);
            try
            {
                SetCameraConfig(pGraph, pVGAWebCam, videoSet1);
            }
            catch
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log("Error: Can't set format", w);
                }
            }

            hr = ((IAMStreamConfig)pinCaptOut).GetFormat(out AMMediaType mediatype);
            CheckHR(hr, "Не удалось получить настройки для камеры");
            VideoInfoHeader v = new VideoInfoHeader();
            Marshal.PtrToStructure(mediatype.formatPtr, v);
            int FrameHeight = v.BmiHeader.Height; // переменная для отображения
            int FrameWidth = v.BmiHeader.Width; // переменная для отображения
            pBuilderV.RenderStream(PinCategory.Preview, MediaType.Video, pVGAWebCam, null, null);
            if (capture)
            {
                if (Properties.Settings.Default.format == ".wmv")
                {
                    pBuilderV.SetOutputFileName(MediaSubType.Asf, dstFile1, out IBaseFilter pWMASFWriter, out IFileSinkFilter sink);
                    ConfigProfileFromFile(pWMASFWriter, FrameHeight, FrameWidth);
                    pBuilderV.RenderStream(PinCategory.Capture, MediaType.Video, pVGAWebCam, null, pWMASFWriter);
                    pBuilderV.RenderStream(PinCategory.Capture, MediaType.Audio, pRealtekRAudio, null, pWMASFWriter);
                }
                else
                {
                    pBuilderV.SetOutputFileName(MediaSubType.Avi, dstFile1, out IBaseFilter AVIWriter, out IFileSinkFilter sink);
                    pBuilderV.RenderStream(PinCategory.Capture, MediaType.Video, pVGAWebCam, null, AVIWriter);
                    pBuilderV.RenderStream(PinCategory.Capture, MediaType.Audio, pRealtekRAudio, null, AVIWriter);
                }

            }
        }
        #endregion
        #region XmlDocHelpers
        string PRX_GuidVideoStream = "{73646976-0000-0010-8000-00AA00389B71}";
        bool AttributeEqualsValue(XmlAttribute xat, string xval)
        {
            if (xat == null) return false;
            return (xat.Value == xval);
        }
        bool SetAttributeIfFound(XmlNode xnode, string atName, object atValue)
        {
            XmlAttribute xat = xnode.Attributes[atName];
            if (xat != null)
            {
                xat.InnerXml = atValue.ToString();
                return true;
            }
            else
                return false;
        }
        bool FindChildByName(XmlNode parent, string elementName, out XmlNode childNode)
        {
            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == elementName)
                {
                    childNode = child;
                    return true;
                }
            }
            childNode = null;
            return false;
        }
        #endregion
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
        private void SetProfileFrameSize(ref string txtWMPrf, int width, int height)
        {
            Console.WriteLine("Setting WMProfile Frame size to: " + width.ToString() + " x " + height.ToString());
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(txtWMPrf);
            XmlNode root = xDoc.DocumentElement;
            foreach (XmlNode rootchild in root.ChildNodes)
            {
                if (rootchild.Name == "streamconfig")
                {
                    if (AttributeEqualsValue(rootchild.Attributes["majortype"], PRX_GuidVideoStream))
                    {
                        XmlNode passChild = rootchild;
                        AddFrameSizesToVideoStreamConfig(ref passChild, width, height);
                        break;
                    }
                }
            }
            txtWMPrf = xDoc.InnerXml;
        }
        void AddFrameSizesToVideoStreamConfig(ref XmlNode streamconfig, int width, int height)
        {
            // bool foo;
            XmlNode xnode;
            if (FindChildByName(streamconfig, "wmmediatype", out XmlNode xnodewmmediatype))
            {
                if (FindChildByName(xnodewmmediatype, "videoinfoheader", out XmlNode xnodevidinfoheader))
                {
                    if (FindChildByName(xnodevidinfoheader, "rcsource", out xnode))
                    {
                        SetAttributeIfFound(xnode, "right", width);
                        SetAttributeIfFound(xnode, "bottom", height);
                    }
                    if (FindChildByName(xnodevidinfoheader, "rctarget", out xnode))
                    {
                        SetAttributeIfFound(xnode, "right", width);
                        SetAttributeIfFound(xnode, "bottom", height);
                    }
                    if (FindChildByName(xnodevidinfoheader, "bitmapinfoheader", out xnode))
                    {
                        SetAttributeIfFound(xnode, "biwidth", width);
                        SetAttributeIfFound(xnode, "biheight", height);
                    }
                }
            }
        }
        public void ConfigProfileFromFile(IBaseFilter asfWriter, int FrameHeight, int FrameWidth)
        {
            string filename = "test.prx";
            string profileData;
            using (Stream stream = this.GetType().Assembly.
           GetManifestResourceStream("assembly.folder." + filename))
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
                {
                    profileData = reader.ReadToEnd();
                }
            }
            WMUtils.WMCreateProfileManager(out IWMProfileManager profileManager);
            SetProfileFrameSize(ref profileData, FrameWidth, FrameHeight);
            profileManager.LoadProfileByData(profileData, out IWMProfile wmProfile);

            if (profileManager != null)
                Marshal.ReleaseComObject(profileManager);

            WindowsMediaLib.IConfigAsfWriter configWriter = (WindowsMediaLib.IConfigAsfWriter)asfWriter;
            configWriter.ConfigureFilterUsingProfile(wmProfile);
        }
        static void SetCameraConfig(IGraphBuilder pGraph, IBaseFilter pVGAWebCamP, int sel_height)
        {
            int hr;
            int prev_height = 0;
            int height, width;
            bool no_compression = false;
            ICaptureGraphBuilder2 pBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
            hr = pBuilder.SetFiltergraph(pGraph);
            CheckHR(hr, "Не удается передать граф построителю графов");
            pBuilder.FindInterface(PinCategory.Capture, MediaType.Video, pVGAWebCamP, typeof(IAMStreamConfig).GUID, out object comObj);
            IAMStreamConfig iamsc = comObj as IAMStreamConfig;
            AMMediaType mediatypeP = new AMMediaType();
            hr = iamsc.GetNumberOfCapabilities(out int CapCount, out int CapSize);
            CheckHR(hr, "Не удалось получить количество настроек камеры");
            IntPtr pSC = Marshal.AllocHGlobal(CapSize);

            for (int i = 0; i < CapCount; i++)
            {
                hr = iamsc.GetStreamCaps(i, out AMMediaType searchmedia, pSC);
                CheckHR(hr, "Не удалось получить список настроек камеры");
                VideoInfoHeader v = new VideoInfoHeader();
                Marshal.PtrToStructure(searchmedia.formatPtr, v);
                height = v.BmiHeader.Height; // переменная для отображения
                width = v.BmiHeader.Width; // переменная для отображения

                if (searchmedia.subType == MediaSubType.RGB1 || searchmedia.subType == MediaSubType.RGB4 ||
                    searchmedia.subType == MediaSubType.RGB16_D3D_DX7_RT || searchmedia.subType == MediaSubType.RGB16_D3D_DX9_RT ||
                    searchmedia.subType == MediaSubType.RGB32_D3D_DX7_RT || searchmedia.subType == MediaSubType.RGB32_D3D_DX9_RT ||
                    searchmedia.subType == MediaSubType.RGB565 || searchmedia.subType == MediaSubType.RGB555 ||
                    searchmedia.subType == MediaSubType.ARGB32 || searchmedia.subType == MediaSubType.RGB8 ||
                    searchmedia.subType == MediaSubType.YV12 || searchmedia.subType == MediaSubType.YVU9 ||
                    searchmedia.subType == MediaSubType.UYVY || searchmedia.subType == MediaSubType.YVYU ||
                    searchmedia.subType == MediaSubType.IYUV || searchmedia.subType == MediaSubType.AYUV ||
                    searchmedia.subType == MediaSubType.NV12 || searchmedia.subType == MediaSubType.NV24 ||
                    searchmedia.subType == MediaSubType.IMC1 || searchmedia.subType == MediaSubType.IMC2 ||
                    searchmedia.subType == MediaSubType.IMC3 || searchmedia.subType == MediaSubType.IMC4 ||
                    searchmedia.subType == MediaSubType.AI44 || searchmedia.subType == MediaSubType.Y41P ||
                    searchmedia.subType == MediaSubType.RGB24 || searchmedia.subType == MediaSubType.RGB32 ||
                    searchmedia.subType == MediaSubType.YUY2 || searchmedia.subType == MediaSubType.YUYV
                    //  || searchmedia.subType == MediaSubType.I420
                    )
                {
                    no_compression = true;
                    if (sel_height <= 0)
                    {
                        if (height >= prev_height && height <= 480 && height % 10 == 0 && width % 10 == 0 && height % 100 != 0)
                            mediatypeP = searchmedia;
                    }
                    else
                    {
                        if (sel_height == height && width % 10 == 0)
                        {
                            mediatypeP = searchmedia;
                            break;
                        }
                    }
                }
                if (!no_compression)
                {
                    if (sel_height <= 0)
                    {
                        if (height > prev_height && height <= 480 && height % 10 == 0 && width % 10 == 0 && height % 100 != 0)
                            mediatypeP = searchmedia;
                    }
                    else
                    {
                        if (sel_height == height && width % 10 == 0)
                            mediatypeP = searchmedia;
                    }
                }
                prev_height = height;
            }

            IPin pinCaptOut = DsFindPin.ByCategory(pVGAWebCamP, PinCategory.Capture, 0);
            hr = ((IAMStreamConfig)pinCaptOut).SetFormat(mediatypeP);
            CheckHR(hr, "Не удалось установить настройки камеры");
            VideoInfoHeader vm = new VideoInfoHeader();
            Marshal.PtrToStructure(mediatypeP.formatPtr, vm);
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(vm.BmiHeader.Width + "x" + vm.BmiHeader.Height + " " + mediatypeP.subType.ToString(), w);
            }
            DsUtils.FreeAMMediaType(mediatypeP);
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
        static IPin GetPin(IBaseFilter filter, string pinname)
        {
            int hr = filter.EnumPins(out IEnumPins epins);
            CheckHR(hr, "Can't enumerate pins");
            IntPtr fetched = Marshal.AllocCoTaskMem(4);
            IPin[] pins = new IPin[1];
            while (epins.Next(1, pins, fetched) == 0)
            {
                pins[0].QueryPinInfo(out PinInfo pinfo);
                bool found = (pinfo.name == pinname);
                DsUtils.FreePinInfo(pinfo);
                if (found)
                    return pins[0];
            }
            CheckHR(-1, "Pin not found");
            return null;
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        private void TimerPosition_Tick(object sender, EventArgs e)
        {
            try
            {
                GetCurrentTime();
            }
            catch
            {
                Console.WriteLine("Не удалось получить время");
            }
        }
        private void GetCurrentTime()
        {
            if (currentState == PlayState.Capture || currentState == PlayState.PausedCapture)
            {
                h = TotalSec2 / 3600;
                m = (TotalSec2 - (h * 3600)) / 60;
                s = TotalSec2 - (h * 3600 + m * 60);
                DurationLbl.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
                TotalSec2++;
                hh = TotalSec / 3600;
                mm = (TotalSec - (hh * 3600)) / 60;
                ss = TotalSec - (hh * 3600 + mm * 60);
                currTimeLbl.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
                if (currentState == PlayState.Capture)
                    TotalSec++;
            }
            else
            {
                TotalSec2 = 0;
                TotalSec = 0;
                DurationLbl.Text = "00:00:00";
                currTimeLbl.Text = "00:00:00";
            }
        }

        int GetMode(int cam1, int cam2)
        {
            int mode = 0;
            if (cam1 < 0 && cam2 < 0)
                mode = 0;                                            // режим записи только аудио
            else if (cam1 != -1 && cam2 == -1)
                mode = 1;                                               // режим записи 1 камера
            else if (cam1 != -1 && cam2 != -1)
            {
                if (cam1 == cam2)    // камеры не должны быть равны
                {
                    MessageBox.Show("Ошибка данных: Вы выбрали одну и ту же камеру");
                    return -1;
                }
                else
                {
                    mode = 2;                           // режим записи 2 камеры
                }
            }
            return mode;
        }

        private void FormCapture_Load(object sender, EventArgs e)
        {

            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTip1.SetToolTip(this.stopBtn, "Стоп");
            toolTip1.SetToolTip(this.pauseBtn, "Пауза/Продолжить");
            toolTip1.SetToolTip(this.startRecBtn, "Запись");
            toolTip1.SetToolTip(this.fastAudioRec, "Быстрая запись аудио");
            toolTip1.SetToolTip(this.fastRecCam1, "Быстрая запись (камера 1)");
            toolTip1.SetToolTip(this.fastRecCam2, "Быстрая запись (камера 2)");
            toolTip1.SetToolTip(this.PreviewBtn, "Начать предпросмотр");

            fastRecCam1.Enabled = false;
            fastRecCam2.Enabled = false;
            PreviewBtn.Enabled = false;
            path = Properties.Settings.Default.path;
            if (Properties.Settings.Default.Camera1 != -1 || Properties.Settings.Default.Camera2 != -1)
            {
                PreviewBtn.Enabled = true;
            }
            Console.WriteLine("Micro:{0} Cam1:{1} Cam2:{2}", Properties.Settings.Default.Microphone, Properties.Settings.Default.Camera1, Properties.Settings.Default.Camera2);
        }

        private void StartRec(string path1, string path2, string path3, int mode,
            int audioDevInd, int videoDevInd1, int videoDevInd2, int selCam1, int selCam2, bool enAud, bool capture)
        {
            int hr;
            graphVideo1 = (IGraphBuilder)new FilterGraph();
            mediaControlV1 = (IMediaControl)graphVideo1;
            graphVideo2 = (IGraphBuilder)new FilterGraph();
            mediaControlV2 = (IMediaControl)graphVideo2;
            graphAudio = (IGraphBuilder)new FilterGraph();
            mediaControlA1 = (IMediaControl)graphAudio;

            if (mode == 0 || enAud)
            {
                BuildAudioGraph(graphAudio, path3, audioDevInd);
#if DEBUG
                rot = new DsROTEntry(graphAudio);
#endif
                hr = mediaControlA1.Run(); // запуск графа
                CheckHR(hr, "Не удалось запустить граф");
            }
            if (mode > 0)
            {
                BuildVideoGraph(graphVideo1, path1, audioDevInd, videoDevInd1, selCam1, capture);
#if DEBUG
                rot = new DsROTEntry(graphVideo1);
#endif
                if (mode == 2)
                {
                    BuildVideoGraph(graphVideo2, path2, audioDevInd, videoDevInd2, selCam2, capture);
#if DEBUG
                    rot = new DsROTEntry(graphVideo2);
#endif
                }
            }
        }
        protected static void RemoveAllFilters(IGraphBuilder graphBuilder)
        {
            if (graphBuilder == null)
                return;

            var filtersArray = new List<IBaseFilter>();

            if (graphBuilder == null)
                throw new ArgumentNullException("graphBuilder");

            int hr = graphBuilder.EnumFilters(out IEnumFilters enumFilters);
            DsError.ThrowExceptionForHR(hr);
            try
            {
                var filters = new IBaseFilter[1];
                IntPtr fetched = IntPtr.Zero;

                while (enumFilters.Next(filters.Length, filters, fetched) == 0)
                {
                    filtersArray.Add(filters[0]);
                }
            }
            finally
            {
                Marshal.ReleaseComObject(enumFilters);
            }
            for (int i = 0; i < filtersArray.Count; i++)
            {
                graphBuilder.RemoveFilter(filtersArray[i]);
                while (Marshal.ReleaseComObject(filtersArray[i]) > 0)
                { }
            }
        }

        private void StopRec(List<object> toStop)
        {
            if (mediaControlA1 == null)
                return;

            mediaControlA1.Stop();
            mediaControlV1.Stop();
            mediaControlV2.Stop();
            RstatusLbl.Text = "Остановлено";
            RemoveAllFilters(graphAudio);
            RemoveAllFilters(graphVideo1);
            RemoveAllFilters(graphVideo2);
            try
            {
#if DEBUG
                if (rot != null)
                {
                    rot.Dispose();
                    rot = null;
                }
#endif
                if (mediaControlA1 != null)
                {
                    mediaControlA1 = null;
                }
                for (int x = 0; x < toStop.Count; x++)
                {
                    if (toStop[x] != null)
                    {
                        toStop[x] = null;
                    }
                }
                GC.Collect();
            }
            catch
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log("Не удалось остановить видео", w);
                }
            }
        }
        private void ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^\w_\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }
        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            int videoDevInd1 = Properties.Settings.Default.Camera1;             // индекс выбранной первой камеры
            int videoDevInd2 = Properties.Settings.Default.Camera2;             // индекс выбранной второй камеры     
            int mode = GetMode(videoDevInd1, videoDevInd2);         // режим записи по умолчанию (0-только аудио) 
            bool enAud = Properties.Settings.Default.AudioOn;                   // записать отдельно аудиофайл
            if (mode >= 0)
            {
                try
                {
                    StartRecClicked(mode, videoDevInd1, videoDevInd2, enAud, false);
                }
                catch (COMException ex)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void StartRecClicked(int mode, int videoDevInd1, int videoDevInd2, bool enAud, bool capture)
        {
            // 1. Получение данных и их проверка
            string testID = ID.Text;                                   //номер исследования
            string curTime = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}",
                DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);           // текущее время
            path += @"\";                                                            // путь для сохранения файлов
            string path1 = path + testID + "_" + "cam1_" + curTime + Properties.Settings.Default.format;                          // записать отдельно аудиофайл;         // имя файла для первой камеры
            string path2 = path + testID + "_" + "cam2_" + curTime + Properties.Settings.Default.format;         // имя файла для второй камеры
            string path3 = path + testID + "_" + "aud1_" + curTime + ".wma";         // имя файла для микрофона
            int audioDevInd = Properties.Settings.Default.Microphone;               // индекс выбранного микрофона
            int resCam1 = Properties.Settings.Default.Resolution1;    // индекс выбранных насроек первой камеры
            int resCam2 = Properties.Settings.Default.Resolution2;    // индекс выбранных настроек второй камеры
            bool isOk = true;                                       // флаг для проверки данных
            string[] modeLBL = { "Только аудио", "1 камера", "2 камеры" };
            if (Properties.Settings.Default.Microphone < 0)
            {
                MessageBox.Show("Ошибка данных: Нет подключенных микрофонов!");
                isOk = false;
            }
            
            if (!Directory.Exists(path) && isOk)
            {
                MessageBox.Show("Ошибка данных: Выберите другой путь!");
                isOk = false;
            }
            if (isOk)
            {
                if (currentState == PlayState.Preview)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                }
                Form frm = Application.OpenForms["Form2"];
                if (frm != null)
                    frm.Close();
                int hr;

                StartRec(path1, path2, path3, mode, audioDevInd, videoDevInd1, videoDevInd2, resCam1, resCam2, enAud, capture);
                int cap = 0;
                if (capture)
                {
                    VideoStart = DateTime.Now;
                    TimeSpan timeDifference = VideoStart - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    long unixEpochTime = Convert.ToInt64(timeDifference.TotalSeconds);
                    //tableName = "table" + unixEpochTime.ToString();
                    //SqliteDataAccess.CreateTimeTable(tableName);
                    //using (StreamWriter w = File.AppendText("log.txt"))
                    //{
                    //    Log("Имя созданной таблицы: " + tableName, w);
                    //}
                    //LoadTimeList(tableName);
                    cap = 1;
                    RstatusLbl.Text = "Идет запись...";
                    currentState = PlayState.Capture;
                    startRecBtn.Enabled = false;
                   // TimeListPanel.Enabled = true;
                }
                else
                {
                    currentState = PlayState.Preview;
                    RstatusLbl.Text = "Предпросмотр";
                }
                
                fastAudioRec.Enabled = false;
                fastRecCam1.Enabled = false;
                fastRecCam2.Enabled = false;
                PreviewBtn.Enabled = false;
                stopBtn.Enabled = true;
                Application.DoEvents();
                modeLbl.Text = "Режим записи:" + modeLBL[mode];
                if (mode > 0)
                {
                    Form2 newForm = new Form2(graphVideo1, graphVideo2, cap, ID.Text) { ShowInTaskbar = false };
                    newForm.Show();
                    hr = mediaControlV1.Run(); // запуск графа
                    CheckHR(hr, "Не удалось запустить граф V1");
                    if (mode == 2)
                    {
                        hr = mediaControlV2.Run(); // запуск графа
                        CheckHR(hr, "Не удалось запустить граф V2");
                    }
                }
            }
        }

        private void StartRecBtn_Click(object sender, EventArgs e)
        {
            int videoDevInd1 = Properties.Settings.Default.Camera1;             // индекс выбранной первой камеры
            int videoDevInd2 = Properties.Settings.Default.Camera2;             // индекс выбранной второй камеры     
            int mode = GetMode(videoDevInd1, videoDevInd2);         // режим записи по умолчанию (0-только аудио) 
            bool enAud = Properties.Settings.Default.AudioOn;                          // записать отдельно аудиофайл
            if (mode >= 0)
            {
                try
                {
                    StartRecClicked(mode, videoDevInd1, videoDevInd2, enAud, true);
                }
                catch (COMException ex)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void FastAudioRec_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Microphone >= 0)
            {
                try
                {
                    StartRecClicked(0, -1, -1, true, true);
                }
                catch (COMException ex)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Ошибка данных: Не подключен микрофон");
            }
        }
        private void FastRecCam1_Click(object sender, EventArgs e)
        {

        }
        private void FastRecCam2_Click(object sender, EventArgs e)
        {
            int videoDevInd1 = Properties.Settings.Default.Camera2;
            if (videoDevInd1 == -1)
            {
                MessageBox.Show("Ошибка данных: Не выбрана вторая камера!");
            }
            else
            {
                try
                {
                    StartRecClicked(1, videoDevInd1, -1, false, true);
                }
                catch (COMException ex)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            int hr;
            if (currentState == PlayState.Preview)
                return;
            if (currentState == PlayState.PausedCapture || currentState == PlayState.Capture)
            {
                switch (currentState)
                {
                    case PlayState.PausedCapture:
                        hr = mediaControlA1.Run();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlV1.Run();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlV2.Run();
                        DsError.ThrowExceptionForHR(hr);
                        startRecBtn.Enabled = false;
                        stopBtn.Enabled = true;
                        RstatusLbl.Text = "Идет запись...";
                        currentState = PlayState.Capture;
                        break;
                    case PlayState.Capture:
                        hr = mediaControlA1.Pause();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlV1.Pause();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlV2.Pause();
                        DsError.ThrowExceptionForHR(hr);
                        RstatusLbl.Text = "Пауза";
                        currentState = PlayState.PausedCapture;
                        break;
                }

            }
            if (currentState == PlayState.PausedRunning || currentState == PlayState.Running)
            {
                switch (currentState)
                {
                    case PlayState.PausedRunning:
                        hr = mediaControlPlay.Run();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlPlay2.Run();
                        DsError.ThrowExceptionForHR(hr);
                        RstatusLbl.Text = "Воспроизводится";
                        currentState = PlayState.Running;
                        break;
                    case PlayState.Running:
                        hr = mediaControlPlay.Pause();
                        DsError.ThrowExceptionForHR(hr);
                        hr = mediaControlPlay2.Pause();
                        DsError.ThrowExceptionForHR(hr);
                        RstatusLbl.Text = "Пауза";
                        currentState = PlayState.PausedRunning;
                        break;
                }
            }
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (currentState == PlayState.Init)
                return;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            Form frm = Application.OpenForms["Form2"];
            if (frm != null)
            {
                frm.Location = new Point(0, 0);
                frm.Size = new Size(285, 490);
            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите остановить?", "Остановка процесса", buttons);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                if (currentState == PlayState.Capture || currentState == PlayState.Preview || currentState == PlayState.PausedCapture)
                {
                    List<object> toStop = new List<object>() { graphAudio, mediaControlA1, graphVideo1, mediaControlV1, graphVideo2, mediaControlV2 };
                    StopRec(toStop);
                }

                if (frm != null)
                    frm.Close();
                if (Properties.Settings.Default.Camera1 != -1 || Properties.Settings.Default.Camera2 != -1)
                {
                    PreviewBtn.Enabled = true;
                }
                modeLbl.Text = "Режим записи:";
                //TimeList.DataSource = null;
                //TimeListPanel.Enabled = false;
                currentState = PlayState.Stopped;
                startRecBtn.Enabled = true;
                stopBtn.Enabled = false;
                startRecBtn.Enabled = true;
                fastAudioRec.Enabled = true;
                fastRecCam1.Enabled = true;
                fastRecCam2.Enabled = true;
                
            }
        }

    }

}
