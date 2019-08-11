using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ez2AcWallpapers
{
    /// <summary>
    /// ApplicationContext 상속을 받고 클래스를 Public으로 변경
    /// </summary>
    public class Program : ApplicationContext
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }

        /// <summary>
        /// Form 변수 선언
        /// </summary>
        public Form1 m_Form1 = new Form1();
        public Form2 m_Form2 = new Form2();
        public Form3 m_Form3 = new Form3();

        /// <summary>
        /// 선언자
        /// </summary>
        Program()
        {
            m_Form1.g_program = m_Form3.g_program = this;
            m_Form1.Show();
            m_Form2.Show();

            // Form3가 밝기 조절 폼이므로 맨 마지막에 실행되어야 함
            m_Form3.Show();
        }
    }
}
