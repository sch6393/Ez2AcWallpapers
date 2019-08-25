using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Runtime.InteropServices;

using MetroFramework.Forms;

using SCHLibFont;

namespace Ez2AcWallpapers
{
    public partial class Form4 : MetroForm
    {
        /// <summary>
        /// 폰트 메모리 등록
        /// </summary>
        /// <param name="pbFont"></param>
        /// <param name="cbFont"></param>
        /// <param name="pdv"></param>
        /// <param name="pcFonts"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        /// <summary>
        /// 폰트 선언
        /// </summary>
        // protected FontFamily m_fontFamily;
        // protected Font m_font;
        protected SCHFont m_SCHFont = new SCHFont();

        public Form4()
        {
            InitializeComponent();

            m_SCHFont.FontCollection();
            FontSet();
        }

        #region Font

        /// <summary>
        /// 폰트 설정
        /// </summary>
        protected void FontSet()
        {
            m_SCHFont.FontSet(label1, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label2, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label3, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label4, 18f, FontStyle.Bold);
            m_SCHFont.FontSet(label5, 18f, FontStyle.Bold);
            m_SCHFont.FontSet(label6, 18f, FontStyle.Bold);
            m_SCHFont.FontSet(label7, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label8, 18f, FontStyle.Bold);
            m_SCHFont.FontSet(label9, 9.75f, FontStyle.Regular);

            //label1.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
            //label2.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
            //label3.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
            //label4.Font = new Font(m_fontFamily, 18f, FontStyle.Bold);
            //label5.Font = new Font(m_fontFamily, 18f, FontStyle.Bold);
            //label6.Font = new Font(m_fontFamily, 18f, FontStyle.Bold);
            //label7.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
        }

        #endregion

        /// <summary>
        /// EZ2AC 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/EZ2Developer");
        }

        /// <summary>
        /// FEII TV 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/vpdl7424");
        }

        /// <summary>
        /// 맨 밑의 라벨 클릭 (github)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sch6393");
        }

        /// <summary>
        /// EZ2AC SOUND 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/EZ2Database");
        }
    }
}
