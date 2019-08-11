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
        protected FontFamily m_FF;
        protected Font m_Font;

        public Form4()
        {
            InitializeComponent();

            FontCollection();
            FontSet(m_Font);
        }

        #region Font

        /// <summary>
        /// 폰트 컬렉션 생성
        /// </summary>
        protected void FontCollection()
        {
            // 해당 폰트 길이만큼 바이트 배열 생성
            byte[] fontArray = Properties.Resources.NanumGothic;
            int dataLength = Properties.Resources.NanumGothic.Length;

            // 메모리를 생성한 후 바이트 배열을 복사
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            // 폰트 리소스 메모리 추가
            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            // PrivateFontCollection 폰트 메모리 추가
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);

            // 남은 메모리 반환
            Marshal.FreeCoTaskMem(ptrData);

            // 초기값
            m_FF = pfc.Families[0];
            m_Font = new Font(m_FF, 15f, FontStyle.Regular);
        }

        /// <summary>
        /// 폰트 설정
        /// </summary>
        /// <param name="font"></param>
        protected void FontSet(Font font)
        {
            // label_Title.Font = new Font(m_FF, 16, FontStyle.Regular);

            label5.Font = new Font(m_FF, 18f, FontStyle.Bold);
            label2.Font = new Font(m_FF, 9.75f, FontStyle.Regular);
            label6.Font = new Font(m_FF, 18f, FontStyle.Bold);
            label3.Font = new Font(m_FF, 9.75f, FontStyle.Regular);
            label4.Font = new Font(m_FF, 18f, FontStyle.Bold);
            label1.Font = new Font(m_FF, 9.75f, FontStyle.Regular);
        }

        /// <summary>
        /// 외부에서 폰트 파일 불러와 설정하기
        /// </summary>
        protected void ExternFontFile()
        {
            try
            {
                // PrivateFontCollection에 폰트 메모리 추가
                PrivateFontCollection m_pf = new PrivateFontCollection();

                // 출력 디렉토리로 복사 설정 = 복사
                m_pf.AddFontFile(Application.StartupPath + @"\Font\Userfont.ttf");

                m_Font = new Font(m_pf.Families[0], 10, FontStyle.Regular);

                FontSet(m_Font);
            }
            catch (Exception)
            {
                // MessageBox.Show("Font 폴더에 'Userfont.ttf' 파일이 존재하지 않습니다!\n시스템 기본 폰트로 실행합니다.", "에러 발생", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Form5.DialogCustom("Error!", "'Userfont.ttf' File Does not Exist in the Font Folder! Run as the System Default Font!");
            }
        }

        #endregion

    }
}
