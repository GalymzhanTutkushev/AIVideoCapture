using System;
using System.Drawing;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;

namespace ADAL_Video
{
    public partial class Form2 : Form
    {
        public Form2(IGraphBuilder graphVideo1, IGraphBuilder graphVideo2, int pcr, string IDtitle)
        {
            InitializeComponent();
            this.graphVideo1 = graphVideo1;
            this.graphVideo2 = graphVideo2;
            this.pcr = pcr;
            this.IDtitle = IDtitle;
        }
        IGraphBuilder graphVideo1, graphVideo2;
        private IVideoWindow videoWindowC = null;
        private IVideoWindow videoWindowC2 = null;
        private IBasicVideo basicVideoF1 = null;
        private IBasicVideo basicVideoF2 = null;
        float k1 = 0;
        float k2 = 0;
        readonly string IDtitle;
        int hr;
        readonly int pcr;
        bool closeR = false;
        bool closeL = false;

        private void ResizeWindow() // изменение размеров панелей
        {
                if (videoWindowC != null && videoWindowC2 != null && closeR == false && closeL == false)
                {
                    panelCapture.Width = this.Width / 2 - 20;
                    panelCapture.Height = this.Height - (80 + 60);
                    panel2.Width = this.Width / 2 - 20;
                    panel2.Height = this.Height - (80 + 60);
                }
                else if (videoWindowC != null && closeR)
                {
                    panelCapture.Width = this.Width - 40;
                    panelCapture.Height = this.Height - (80 + 60);
                    panel2.Width = 0;
                    panel2.Height = 0;
                }
                else if (videoWindowC2 != null && closeL)
                {
                    panelCapture.Width = 0;
                    panelCapture.Height = 0;
                    panel2.Width = this.Width - 40;
                    panel2.Height = this.Height - (80 + 60);
                }
                panelCapture.Top = 80;
                panelCapture.Left = 10;
                panel2.Top = 80;
                panel2.Left = panelCapture.Width + 10;
           
            Rectangle rc1 = panelCapture.ClientRectangle;
            Rectangle rc2 = panel2.ClientRectangle;
            float y11 = (float)(rc1.Height - (float)(rc1.Width / k1)) / 3;
            float y12 = y11 + (float)(rc1.Width / k1);
            float y21 = (float)(rc2.Height - (float)(rc2.Width / k2)) / 3;
            float y22 = y21 + (float)(rc2.Width / k2);
            float x11 = (float)(rc1.Width - (float)(rc1.Height * k1)) / 3;
            float x12 = x11 + (float)(rc1.Height * k1);
            float x21 = (float)(rc2.Width - (float)(rc2.Height * k2)) / 3;
            float x22 = x21 + (float)(rc2.Height * k2);

            if (videoWindowC != null)
            {
                if ((float)rc1.Width / rc1.Height < k1)
                    videoWindowC.SetWindowPosition(0, (int)y11, rc1.Right, (int)y12);
                else
                    videoWindowC.SetWindowPosition((int)x11, 0, (int)x12, rc1.Bottom);
            }

            if (videoWindowC2 != null)
            {
                if ((float)rc2.Width / rc2.Height < k2)
                    videoWindowC2.SetWindowPosition(0, (int)y21, rc2.Right, (int)y22);
                else
                    videoWindowC2.SetWindowPosition((int)x21, 0, (int)x22, rc2.Bottom);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            closeLeft.Enabled = false;
            closeRight.Enabled = false;
            if (this.graphVideo1 != null)
            {
                this.videoWindowC = this.graphVideo1 as IVideoWindow;
                this.basicVideoF1 = this.graphVideo1 as IBasicVideo;
                basicVideoF1.get_VideoHeight(out int h1);
                basicVideoF1.get_VideoWidth(out int w1);
                k1 = (float)w1 / h1;
                hr = videoWindowC.put_Owner(panelCapture.Handle);
                if (hr == 0)
                {
                    hr = videoWindowC.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipChildren);
                    videoWindowC.put_Visible(OABool.True);
                }
            }
            if (this.graphVideo2 != null)
            {
                this.videoWindowC2 = this.graphVideo2 as IVideoWindow;
                this.basicVideoF2 = this.graphVideo2 as IBasicVideo;
                basicVideoF2.get_VideoHeight(out int h2);
                basicVideoF2.get_VideoWidth(out int w2);
                k2 = (float)w2 / h2;
                hr = videoWindowC2.put_Owner(panel2.Handle);
                if (hr == 0)
                {
                    hr = videoWindowC2.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipChildren);
                    videoWindowC2.put_Visible(OABool.True);
                }
                if (w2 == 0)
                {
                    closeR = true;
                    closeL = false;
                    this.Height = 600;
                    this.Width = 640;
                }
            }
            if (videoWindowC != null && videoWindowC2 != null)
            {
                closeLeft.Enabled = true;
                closeRight.Enabled = true;
            }
            
            ResizeWindow();
            if (pcr == 0)
                this.Text = "Предпросмотр: " + IDtitle;
            else if (pcr == 1)
                this.Text = "Запись: " + IDtitle;
            else if (pcr == 2)
                this.Text = "Воспроизведение: " + IDtitle;
        }
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            ResizeWindow();
        }
       
        private void CloseLeft_Click(object sender, EventArgs e)
        {
            closeL = true;
            closeR = false;
            ResizeWindow();
        }
        private void CloseRight_Click(object sender, EventArgs e)
        {
            closeR = true;
            closeL = false;
            ResizeWindow();
        }
        private void Form2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // ResizeWindow();
        }

        private void SetFullScreen_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.videoWindowC != null)
            {
                Marshal.ReleaseComObject(this.videoWindowC);
                this.videoWindowC = null;
            }
            if (this.videoWindowC2 != null)
            {
                Marshal.ReleaseComObject(this.videoWindowC2);
                this.videoWindowC2 = null;
            }
            if (this.graphVideo1 != null)
            {
                Marshal.ReleaseComObject(this.graphVideo1);
                this.graphVideo1 = null;
            }
            if (this.graphVideo2 != null)
            {
                Marshal.ReleaseComObject(this.graphVideo2);
                this.graphVideo2 = null;
            }
            if (this.basicVideoF1 != null)
            {
                Marshal.ReleaseComObject(this.basicVideoF1);
                this.basicVideoF1 = null;
            }
            if (this.basicVideoF2 != null)
            {
                Marshal.ReleaseComObject(this.basicVideoF2);
                this.basicVideoF2 = null;
            }
        }
    }
}
