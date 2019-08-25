using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SCHLibWallpaper;

namespace Ez2AcWallpapers
{
    public partial class Form3 : Form
    {
        /// <summary>
        /// Program 주 진입점 선언
        /// </summary>
        public Program g_program;

        public Form3()
        {
            InitializeComponent();

            Background();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            g_program.ExitThread();
        }

        #region Background

        protected bool Background()
        {
            Form1.m_bFixed = Wallpaper.Background(this.Handle);

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

        #region Brightness Control

        protected override void WndProc(ref Message m)
        {
            // WM_NCHITTEST
            if (m.Msg == 0x0084)
            {
                // HTTRANSPARENT
                m.Result = (IntPtr)(-1);
            }
            else
            {
                base.WndProc(ref m);
            }
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
