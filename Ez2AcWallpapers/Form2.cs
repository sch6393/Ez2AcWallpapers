using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ez2AcWallpapers
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Background();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Timer.Stop();
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            SetVolume();
        }

        #region Background

        protected bool Background()
        {
            Form1.m_bFixed = Ez2AcWallpapers.Wallpaper.Background(this.Handle);

            if (Form1.m_bFixed)
            {
                Utility.FillMonitor(this, MonitorInfo);
            }

            return Form1.m_bFixed;
        }

        public WinApi.MONITORINFO MonitorInfo
        {
            get
            {
                return new WinApi.MONITORINFO()
                {
                    rcMonitor = Screen.PrimaryScreen.Bounds,
                    rcWork = Screen.PrimaryScreen.WorkingArea,
                };
            }
        }

        #endregion

        #region WindowsMediaPlayer

        public void Play()
        {
            m_Timer.Start();

            axWindowsMediaPlayer.settings.setMode("Loop", true);

            axWindowsMediaPlayer.URL = Form1.m_strFilePath;
            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        public void Pause()
        {
            m_Timer.Stop();

            axWindowsMediaPlayer.Ctlcontrols.pause();
        }

        public void Resume()
        {
            m_Timer.Start();

            axWindowsMediaPlayer.Ctlcontrols.play();
        }

        public void Stop()
        {
            m_Timer.Stop();

            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        public void Prev()
        {
            axWindowsMediaPlayer.Ctlcontrols.previous();
        }

        public void Next()
        {
            axWindowsMediaPlayer.Ctlcontrols.next();
        }

        private void SetVolume()
        {
            axWindowsMediaPlayer.settings.volume = Form1.m_iVolume;
        }

        #endregion

        #region Alt + Tab Unvisible

        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on WS_EX_TOOLWINDOW style bit
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x80;

                return cp;
            }
        }

        #endregion

    }
}
