using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Ez2AcWallpapers
{
    public static class WinApi
    {
        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0,
            SMTO_BLOCK = 0x1,
            SMTO_ABORTIFHUNG = 0x2,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
            SMTO_ERRORONEXIT = 0x20
        }

        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        public const int MONITOR_DEFAULTTONULL = 0;
        public const int MONITOR_DEFAULTTOPRIMARY = 1;
        public const int MONITOR_DEFAULTTONEAREST = 2;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public int Height
            {
                get
                {
                    return Bottom - Top;
                }
                set
                {
                    Bottom = value + Top;
                }
            }

            public int Width
            {
                get
                {
                    return Right - Left;
                }
                set
                {
                    Right = value + Left;
                }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {

            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public int cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, int dwData);

        /// <summary>
        /// 윈도우 컨트롤 찾기 (상위)
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 윈도우 컨트롤 찾기 (하위)
        /// </summary>
        /// <param name="parentHandle"></param>
        /// <param name="childAfter"></param>
        /// <param name="className"></param>
        /// <param name="windowTitle"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        /// <summary>
        /// 메시지 받기
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        /// <summary>
        /// 프로그램 목록
        /// </summary>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// 상위 클래스 설정
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="hWndNewParent"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// 윈도우 컨트롤 표시 상태
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 윈도우 컨트롤 위치, 크기
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="bRepaint"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// 모니터 정보
        /// </summary>
        /// <param name="hMonitor"></param>
        /// <param name="lpmi"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);
    }
}