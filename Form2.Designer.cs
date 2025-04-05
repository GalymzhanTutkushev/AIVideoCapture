namespace ADAL_Video
{
    partial class Form2
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
            this.panelCapture = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeRight = new System.Windows.Forms.Button();
            this.closeLeft = new System.Windows.Forms.Button();
            this.SetFullScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelCapture
            // 
            this.panelCapture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panelCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCapture.Location = new System.Drawing.Point(10, 69);
            this.panelCapture.Name = "panelCapture";
            this.panelCapture.Size = new System.Drawing.Size(346, 240);
            this.panelCapture.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(372, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 240);
            this.panel2.TabIndex = 1;
            // 
            // closeRight
            // 
            this.closeRight.BackgroundImage = global::ADAL_Video.Properties.Resources.closing_right;
            this.closeRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeRight.Location = new System.Drawing.Point(10, 12);
            this.closeRight.Name = "closeRight";
            this.closeRight.Size = new System.Drawing.Size(50, 50);
            this.closeRight.TabIndex = 6;
            this.closeRight.UseVisualStyleBackColor = true;
            this.closeRight.Click += new System.EventHandler(this.CloseRight_Click);
            // 
            // closeLeft
            // 
            this.closeLeft.BackgroundImage = global::ADAL_Video.Properties.Resources.closing_left;
            this.closeLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeLeft.Location = new System.Drawing.Point(66, 12);
            this.closeLeft.Name = "closeLeft";
            this.closeLeft.Size = new System.Drawing.Size(50, 50);
            this.closeLeft.TabIndex = 5;
            this.closeLeft.UseVisualStyleBackColor = true;
            this.closeLeft.Click += new System.EventHandler(this.CloseLeft_Click);
            // 
            // SetFullScreen
            // 
            this.SetFullScreen.Location = new System.Drawing.Point(122, 14);
            this.SetFullScreen.Name = "SetFullScreen";
            this.SetFullScreen.Size = new System.Drawing.Size(48, 48);
            this.SetFullScreen.TabIndex = 7;
            this.SetFullScreen.Text = "button1";
            this.SetFullScreen.UseVisualStyleBackColor = true;
            this.SetFullScreen.Click += new System.EventHandler(this.SetFullScreen_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 329);
            this.ControlBox = false;
            this.Controls.Add(this.SetFullScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.closeRight);
            this.Controls.Add(this.closeLeft);
            this.Controls.Add(this.panelCapture);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCapture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button closeLeft;
        private System.Windows.Forms.Button closeRight;
        private System.Windows.Forms.Button SetFullScreen;
    }
}