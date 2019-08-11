using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Ez2AcWallpapers
{
    public static class Utility
    {
        static Utility()
        {
            Initialize();
        }

        private static WinApi.RECT m_staticRECT;

        public static WinApi.MONITORINFO[] g_staticMONITORINFO
        {
            get;
            private set;
        }

        public static void Initialize()
        {
            m_staticRECT = new WinApi.RECT(0, 0, 0, 0);

            List<WinApi.MONITORINFO> listMONITORINFO = new List<WinApi.MONITORINFO>();

            WinApi.MonitorEnumDelegate callback = (IntPtr hDesktop, IntPtr hdc, ref WinApi.RECT pRect, int d) =>
            {
                var varInfo = new WinApi.MONITORINFO();

                varInfo.cbSize = sizeof(int) * 4 * 2 + sizeof(int) * 2;

                if (WinApi.GetMonitorInfo(hDesktop, ref varInfo) == false)
                    return false;

                var varMONITORINFO = varInfo.rcMonitor;

                if (varMONITORINFO.Left < m_staticRECT.Left)
                {
                    m_staticRECT.Left = varMONITORINFO.Left;
                }

                if (varMONITORINFO.Top < m_staticRECT.Top)
                {
                    m_staticRECT.Top = varMONITORINFO.Top;
                }

                if (varMONITORINFO.Right > m_staticRECT.Right)
                {
                    varMONITORINFO.Right = m_staticRECT.Right;
                }

                if (varMONITORINFO.Bottom > m_staticRECT.Bottom)
                {
                    varMONITORINFO.Bottom = m_staticRECT.Bottom;
                }

                listMONITORINFO.Add(varInfo);

                return true;
            };

            g_staticMONITORINFO = new[]
            {
                new WinApi.MONITORINFO()
                {
                    rcMonitor = Screen.PrimaryScreen.Bounds,
                    rcWork = Screen.PrimaryScreen.WorkingArea,
                }
            };
        }

        public static void FillMonitor(Form form, WinApi.MONITORINFO monitorInfo)
        {
            var varMONITORINFO = monitorInfo.rcMonitor;

            int iX = varMONITORINFO.Left - m_staticRECT.Left;
            int iY = varMONITORINFO.Top - m_staticRECT.Top;

            WinApi.MoveWindow(form.Handle, iX, iY, varMONITORINFO.Width, varMONITORINFO.Height, false);
        }
    }
}