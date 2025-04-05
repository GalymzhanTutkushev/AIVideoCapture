using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;
using System.IO;

namespace ADAL_Video.Forms
{
    public partial class FormPlay : Form
    {
        public FormPlay()
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
           
            toolTip1.SetToolTip(this.stopBtn, "Стоп");
            toolTip1.SetToolTip(this.pauseBtn, "Пауза/Продолжить");
            toolTip1.SetToolTip(this.saveFrameBtn, "Сохранить кадр (камера 1)");
            toolTip1.SetToolTip(this.stepFrameBtn, "Покадровый просмотр");
            toolTip1.SetToolTip(this.saveFrameBtn2, "Сохранить кадр (камера 2)");
            toolTip1.SetToolTip(this.slowBtn, "Уменшить скорость воспроизведения");
            toolTip1.SetToolTip(this.fastBtn, "Увеличить скорость воспроизведения");
            toolTip1.SetToolTip(this.GoToPos, "Найти и перейти (сек.)");
            VolumeBar.Value = VolumeBar.Maximum;
            PlayPanel.Enabled = false;
            saveFrameBtn.Enabled = false;
            saveFrameBtn2.Enabled = false;
            stepFrameBtn.Enabled = false;
        }
#if DEBUG
        private DsROTEntry rot = null;
#endif
        private IMediaControl  mediaControlPlay, mediaControlPlay2 = null;
        private IGraphBuilder  graphPlay, graphPlay2 = null;
        private IMediaPosition mediaPosition, mediaPosition2 = null;
        private IVideoFrameStep frameStep, frameStep2 = null;
        private IBasicVideo basicVideo, basicVideo2 = null;
        private IBasicAudio basicAudio, basicAudio2 = null;
        int h, m, s;        //время воспроизведения
        int hh, mm, ss;    // время записи
        private PlayState currentState;
        bool flag = false;
        private double currentPlaybackRate = 1.0;
        private void SlowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SetRate(0.5);
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(ex.Message, w);
                }
            }
        }
        private void FastBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SetRate(2);
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(ex.Message, w);
                }
            }
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
        private void GoToPos_Click(object sender, EventArgs e)
        {
            if (mediaPosition == null)
                return;
            TimeSpan timp = TimePicker.Value.TimeOfDay;
            int timePos = (int)timp.TotalSeconds;
            mediaPosition.get_Duration(out double pLength);
            if (timePos < 0 || timePos > pLength)
                return;

            mediaPosition.put_CurrentPosition(timePos);
            mediaPosition2.put_CurrentPosition(timePos);
        }
        private void SaveFrameBtn_Click(object sender, EventArgs e)
        {
            SaveFrame(basicVideo);
        }
        private void SaveFrameBtn2_Click(object sender, EventArgs e)
        {
            SaveFrame(basicVideo2);
        }
        private void PositionTracker_Scroll(object sender, EventArgs e)
        {
            if (mediaPosition == null)
                return;
            mediaPosition.put_CurrentPosition((long)PositionTracker.Value);
            mediaPosition2.put_CurrentPosition((long)PositionTracker.Value);
        }
        private void StepFrameBtn_Click(object sender, EventArgs e)
        {
            if (frameStep != null || frameStep2 != null)
            {
                int hr;
                if (currentState != PlayState.PausedRunning)
                {
                    hr = mediaControlPlay.Pause();
                    DsError.ThrowExceptionForHR(hr);
                    hr = mediaControlPlay2.Pause();
                    DsError.ThrowExceptionForHR(hr);
                    RstatusLbl.Text = "Пауза";
                    currentState = PlayState.PausedRunning;
                }
                if (frameStep != null)
                    frameStep.Step(1, null);
                if (frameStep2 != null)
                    frameStep2.Step(1, null);
                RstatusLbl.Text = "Покадровый переход";
            }
            else
            {
                Console.WriteLine("Framestep is null");
            }
        }
        private void volumePic_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                volumePic.BackgroundImage = Properties.Resources.volume;
                VolumeBar.Value = VolumeBar.Maximum;
            }
            else
            {
                volumePic.BackgroundImage = Properties.Resources.no_volume;
                VolumeBar.Value = VolumeBar.Minimum;
            }
            flag = !flag;
        }
        private void SetRate(double rate)
        {
            if (mediaPosition == null)
                return;
            currentPlaybackRate *= rate;
            if (currentPlaybackRate > 4 || currentPlaybackRate < 0.25)
                return;
            int hr;
            hr = mediaPosition.put_Rate(currentPlaybackRate);
            CheckHR(hr, "Не удалось изменить скорость!");
            try
            {
                hr = mediaPosition2.put_Rate(currentPlaybackRate);
            }
            catch
            {

            }
            rateLbl.Text = currentPlaybackRate.ToString() + "x";
        }
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
        private bool GetFrameStepInterface()
        {
            IVideoFrameStep frameStepTest;
            IVideoFrameStep frameStepTest2;
            frameStepTest = (IVideoFrameStep)graphPlay;
            frameStepTest2 = (IVideoFrameStep)graphPlay2;
            int hr, hr1;
            hr = frameStepTest.CanStep(0, null);
            CheckHR(hr, "Can't Frame test 1");
            hr1 = frameStepTest2.CanStep(0, null);
            CheckHR(hr, "Can't Frame test 2");
            if (hr == 0)
                frameStep = frameStepTest;
            if (hr1 == 0)
                frameStep2 = frameStepTest2;
            if (hr == 0 || hr1 == 0)
                return true;
            else
            {
                frameStep = null;
                frameStep2 = null;
                return false;
            }
        }
        private void SaveFrame(IBasicVideo BasicVideo)
        {
            if (mediaControlPlay == null)
                return;
            int hr;
            hr = mediaControlPlay.Pause();
            DsError.ThrowExceptionForHR(hr);
            hr = mediaControlPlay2.Pause();
            DsError.ThrowExceptionForHR(hr);
            RstatusLbl.Text = "Пауза";
            currentState = PlayState.PausedRunning;
            saveFileDialog1.Filter = "JPG files (*.jpg)|*.jpg";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ShowHelp = true;
            saveFileDialog1.AddExtension = true;
            Bitmap bmp;
            IntPtr bvp;
            int size = 0;
            BasicVideo.GetCurrentImage(ref size, IntPtr.Zero);
            bvp = Marshal.AllocCoTaskMem(size);
            hr = BasicVideo.GetCurrentImage(ref size, bvp);
            DsError.ThrowExceptionForHR(hr);
            BitmapInfoHeader structure = new BitmapInfoHeader();
            Marshal.PtrToStructure(bvp, structure);
            bmp = new Bitmap(structure.Width, structure.Height, (structure.BitCount / 8) * structure.Width, System.Drawing.Imaging.PixelFormat.Format32bppArgb, new IntPtr(bvp.ToInt64() + 40));
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                bmp.Save(saveFileDialog1.FileName.ToString(), System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }


        private void GetCurrentTime()
        {
            if (currentState == PlayState.Running || currentState == PlayState.PausedRunning)
            {
                basicAudio.put_Volume(-7000 + 7000 * VolumeBar.Value / VolumeBar.Maximum);
                mediaPosition.get_CurrentPosition(out double pos);
                mediaPosition.get_Duration(out double pLen);
                if (pos == pLen)
                    mediaPosition.put_CurrentPosition(0);

                s = (int)pos;
                if (s >= 0)
                    PositionTracker.Value = s;

                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s -= (h * 3600 + m * 60);
                currTimeLbl.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            
            else
            {

                DurationLbl.Text = "00:00:00";
                currTimeLbl.Text = "00:00:00";
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
        private void StopVideo()
        {
            if (mediaControlPlay == null)
                return;

            mediaControlPlay.Stop();
            mediaControlPlay2.Stop();
            RstatusLbl.Text = "Остановлено";
            RemoveAllFilters(graphPlay);
            RemoveAllFilters(graphPlay2);
            rateLbl.Text = "1.0x";
            try
            {
#if DEBUG
                if (rot != null)
                {
                    rot.Dispose();
                    rot = null;
                }
#endif
                if (mediaControlPlay != null)
                    mediaControlPlay = null;
                if (mediaControlPlay2 != null)
                    mediaControlPlay2 = null;
                if (frameStep != null)
                    frameStep = null;
                if (frameStep2 != null)
                    frameStep2 = null;
                if (mediaPosition != null)
                    mediaPosition = null;
                if (mediaPosition2 != null)
                    mediaPosition2 = null;
                if (basicVideo != null)
                    basicVideo = null;
                if (basicVideo2 != null)
                    basicVideo2 = null;
                if (basicAudio != null)
                    basicAudio = null;
                if (basicAudio2 != null)
                    basicAudio2 = null;
                if (graphPlay != null)
                {
                    Marshal.ReleaseComObject(graphPlay);
                    graphPlay = null;
                }
                if (graphPlay2 != null)
                {
                    Marshal.ReleaseComObject(graphPlay2);
                    graphPlay2 = null;
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

        private void PlayVideo(string mediafile)
        {
            int hr;
            graphPlay = (IGraphBuilder)new FilterGraph();
            graphPlay2 = (IGraphBuilder)new FilterGraph();
            mediaControlPlay = (IMediaControl)graphPlay;
            mediaControlPlay2 = (IMediaControl)graphPlay2;
            mediaPosition = (IMediaPosition)graphPlay;
            mediaPosition2 = (IMediaPosition)graphPlay2;
            basicVideo = (IBasicVideo)graphPlay;
            basicVideo2 = (IBasicVideo)graphPlay2;
            basicAudio = (IBasicAudio)graphPlay;
            basicAudio2 = (IBasicAudio)graphPlay2;
            string video1 = "";
            string video2 = "";
            string path = Path.GetDirectoryName(mediafile);
            string file = Path.GetFileName(mediafile);
            FileInfo fi = new FileInfo(Path.Combine(path, file));
            DateTime creationTime1 = fi.CreationTime;
            string fe = fi.Extension;
            Console.WriteLine("Дата создания файла: {0}", creationTime1);
            if ((file.EndsWith(".avi") || file.EndsWith(".mp4") || file.EndsWith(".wmv") || file.EndsWith(".wma")))
                video1 = Path.Combine(path, file);

            string[] files = Directory.GetFiles(path);
            DateTime creationTime2;
            FileInfo fi2;
            Console.WriteLine(video1);
            if (video1 != "" && !file.EndsWith(".wma"))
            {
                foreach (string f in files)
                {
                    string curF = Path.GetFileName(f);
                    fi2 = new FileInfo(f);
                    creationTime2 = fi2.CreationTime;

                    if (Math.Abs((creationTime1 - creationTime2).TotalSeconds) < 1.6 && f != video1 &&
                        (f.EndsWith(".avi") || f.EndsWith(".mp4") || f.EndsWith(".wmv")))
                    {
                        video2 = f;
                        Console.WriteLine((creationTime1 - creationTime2).TotalSeconds);
                    }
                }
            }
            if (video1 == "" && video2 == "")
            {
                MessageBox.Show("Ошибка данных: Имя выбранного файла не соответсвует формату!");
                return;
            }

            if (video2 != "")
                graphPlay2.RenderFile(video2, null);
            if (video1 != "")
                graphPlay.RenderFile(video1, null);

            basicAudio2.put_Volume(-10000);
            GetFrameStepInterface();
#if DEBUG
            rot = new DsROTEntry(graphPlay);
#endif
            Form frm = Application.OpenForms["Form2"];
            if (frm != null)
                frm.Close();

            if (!video1.EndsWith(".wma"))
            {
                Form2 newForm = new Form2(graphPlay, graphPlay2, 2, "") { ShowInTaskbar = false };
                newForm.Show();
            }
            hr = mediaControlPlay2.Run();
            CheckHR(hr, "Can't run the play graph 2");
            hr = mediaControlPlay.Run();
            CheckHR(hr, "Can't run the play graph 1 ");
            Application.DoEvents();
            TimeSpan timeDifference = creationTime1 - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixEpochTime = Convert.ToInt64(timeDifference.TotalSeconds);
            //tableName = "table" + unixEpochTime.ToString();
            using (StreamWriter w = File.AppendText("log.txt"))
            {
              //  Log("Имя выбираемой таблицы: " + tableName, w);
            }
            //LoadTimeList(tableName);
            currentState = PlayState.Running;
            RstatusLbl.Text = "Воспроизводится";
            stopBtn.Enabled = true;
            GoToPos.Enabled = true;
            PlayPanel.Enabled = true;

            //TimeListPanel.Enabled = true;
            if (video1 != "" && !(video1.EndsWith(".wma")))
            {
                stepFrameBtn.Enabled = true;
                saveFrameBtn.Enabled = true;
            }
            if (video2 != "")
                saveFrameBtn2.Enabled = true;

            if (mediaPosition != null)
            {
                mediaPosition.get_Duration(out double pLength);
                int ss = (int)pLength;
                PositionTracker.Maximum = ss;
                int hh = ss / 3600;
                int mm = (ss - (hh * 3600)) / 60;
                ss -= (hh * 3600 + mm * 60);
                DurationLbl.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
            }
        }
    }
}
