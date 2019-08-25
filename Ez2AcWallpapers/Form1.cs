using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 추가
using System.IO;

// NuGet 패키지
using MetroFramework.Forms;

using SCHLibFont;

namespace Ez2AcWallpapers
{
    public partial class Form1 : MetroForm
    {
        /// <summary>
        /// Program 주 진입점 선언
        /// </summary>
        public Program g_program;

        /// <summary>
        /// 폰트 선언
        /// </summary>
        // protected FontFamily m_fontFamily;
        // protected Font m_font;
        protected SCHFont m_SCHFont = new SCHFont();

        /// <summary>
        /// Form2가 필요로 하는 데이터 변수들
        /// (재생할 파일 경로, 볼륨 값)
        /// </summary>
        public static string m_strFilePath = "";
        public static int m_iVolume = 0;


        /// <summary>
        /// 밝기 값
        /// </summary>
        public static int m_iBrightness = 50;

        /// <summary>
        /// Background 변수들
        /// </summary>
        public static bool m_bFixed = false;


        /// <summary>
        /// Flag
        /// 0  : 1st
        /// 1  : 1st Special
        /// 2  : 2nd
        /// 3  : 2nd Event
        /// 4  : 3rd
        /// 5  : 4th
        /// 6  : 4th Event
        /// 7  : Platinum
        /// 8  : 6th
        /// 9  : 7th 1.0
        /// 10 : 7th 1.5
        /// 11 : 7th 2.0
        /// 12 : CV
        /// 13 : BERA
        /// 14 : AEIC
        /// 15 : EC
        /// 16 : EV
        /// 17 : NT
        /// 18 : CV2
        /// 19 : TT
        /// 20 : White Out
        /// 21 : North Pole
        /// 22 : FN
        /// 23 : 3S
        /// </summary>
        protected bool[] m_bFlag = new bool[24];

        // 첫 탭 페이지 설정
        protected int m_iSelect = 15;
        // protected int m_iTile = 0;

        public Form1()
        {
            InitializeComponent();

            m_SCHFont.FontCollection();
            FontSet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 밝기 조절
            SetBrightness(m_iBrightness);

            tabControl.SelectTab(m_iSelect);

            // Flag 초기화
            for (int i = 0; i < m_bFlag.Length; i++)
            {
                m_bFlag[i] = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 메모리, 리소스 해제 및 메세지 처리 후 종료
            g_program.ExitThread();

            Dispose();
            Application.Exit();
        }

        #region Font

        /// <summary>
        /// 폰트 설정
        /// </summary>
        protected void FontSet()
        {
            m_SCHFont.FontSet(tabControl, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label_Volume, 9.75f, FontStyle.Regular);
            m_SCHFont.FontSet(label_Brightness, 9.75f, FontStyle.Regular);

            //tabControl.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
            //label_Volume.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
            //label_Brightness.Font = new Font(m_fontFamily, 9.75f, FontStyle.Regular);
        }

        #endregion

        #region Function

        /// <summary>
        /// 밝기 조절
        /// Form3의 기본 Opacity 값은 50%으로 설정
        /// </summary>
        protected void SetBrightness(int itmp)
        {
            float ftmp = itmp * 0.01f;

            if (ftmp < 0.5f)
            {
                g_program.m_Form3.Opacity = 1 - 2 * ftmp;
                g_program.m_Form3.BackColor = Color.Black;
            }
            else
            {
                g_program.m_Form3.Opacity = 2 * (ftmp - 0.5f);
                g_program.m_Form3.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 재생
        /// </summary>
        protected void Play()
        {
            Stop();

            g_program.m_Form2.Play();
        }

        /// <summary>
        /// 정지
        /// </summary>
        protected void Stop()
        {
            g_program.m_Form2.Stop();
        }

        /// <summary>
        /// Flag 초기화
        /// </summary>
        protected void InitFlag(int itmp)
        {
            for (int i = 0; i < m_bFlag.Length; i++)
            {
                m_bFlag[i] = true;
            }

            if (itmp == -1)
                return;

            m_bFlag[itmp] = false;
        }

        /// <summary>
        /// 타일 클릭
        /// </summary>
        protected void Tiles(int itmp)
        {
            // 파일 이름 사용 중 우회
            if (itmp == -1)
            {
                string strtmp = string.Format("{0}.mp4", itmp.ToString());
                var varFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), strtmp);

                m_strFilePath = varFile;

                Play();

                return;
            }

            if (m_bFlag[itmp])
            {
                string strtmp = string.Format("{0}.mp4", itmp.ToString());
                var varFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), strtmp);

                switch (itmp)
                {
                    case 0:
                        File.WriteAllBytes(varFile, Properties.Resources._1st);
                        break;

                    case 1:
                        File.WriteAllBytes(varFile, Properties.Resources._1st_Special);
                        break;

                    case 2:
                        File.WriteAllBytes(varFile, Properties.Resources._2nd);
                        break;

                    case 3:
                        File.WriteAllBytes(varFile, Properties.Resources._2nd_Event);
                        break;

                    case 4:
                        File.WriteAllBytes(varFile, Properties.Resources._3rd);
                        break;

                    case 5:
                        File.WriteAllBytes(varFile, Properties.Resources._4th);
                        break;

                    case 6:
                        File.WriteAllBytes(varFile, Properties.Resources._4th_Event);
                        break;

                    case 7:
                        File.WriteAllBytes(varFile, Properties.Resources.Platinum);
                        break;

                    case 8:
                        File.WriteAllBytes(varFile, Properties.Resources._6th);
                        break;

                    case 9:
                        File.WriteAllBytes(varFile, Properties.Resources._7th_1_0);
                        break;

                    case 10:
                        File.WriteAllBytes(varFile, Properties.Resources._7th_1_5);
                        break;

                    case 11:
                        File.WriteAllBytes(varFile, Properties.Resources._7th_2_0);
                        break;

                    case 12:
                        File.WriteAllBytes(varFile, Properties.Resources.CV);
                        break;

                    case 13:
                        File.WriteAllBytes(varFile, Properties.Resources.BERA);
                        break;

                    case 14:
                        File.WriteAllBytes(varFile, Properties.Resources.AEIC);
                        break;

                    case 15:
                        File.WriteAllBytes(varFile, Properties.Resources.EC);
                        break;

                    case 16:
                        File.WriteAllBytes(varFile, Properties.Resources.EV);
                        break;

                    case 17:
                        File.WriteAllBytes(varFile, Properties.Resources.NT);
                        break;

                    case 18:
                        File.WriteAllBytes(varFile, Properties.Resources.CV2);
                        break;

                    case 19:
                        File.WriteAllBytes(varFile, Properties.Resources.TT);
                        break;

                    case 20:
                        File.WriteAllBytes(varFile, Properties.Resources.WhiteOut);
                        break;

                    case 21:
                        File.WriteAllBytes(varFile, Properties.Resources.northpole);
                        break;

                    case 22:
                        File.WriteAllBytes(varFile, Properties.Resources.FN);
                        break;

                    case 23:
                        File.WriteAllBytes(varFile, Properties.Resources._3S);
                        break;

                    default:
                        MessageBox.Show("오류가 발생했습니다!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // MessageBox.Show("An Unhandled Exception Occurred!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                }

                m_strFilePath = varFile;

                Play();
                InitFlag(itmp);
            }
        }

        #endregion

        #region Tile Click

        /// <summary>
        /// 1st
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile1_1_Click(object sender, EventArgs e)
        {
            Tiles(0);
        }

        /// <summary>
        /// 1st Special
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile1_2_Click(object sender, EventArgs e)
        {
            Tiles(1);
        }

        /// <summary>
        /// 2nd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile2_1_Click(object sender, EventArgs e)
        {
            Tiles(2);
        }

        /// <summary>
        /// 2nd Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile2_2_Click(object sender, EventArgs e)
        {
            Tiles(3);
        }

        /// <summary>
        /// 3rd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile3_Click(object sender, EventArgs e)
        {
            Tiles(4);
        }

        /// <summary>
        /// 4th
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile4_1_Click(object sender, EventArgs e)
        {
            Tiles(5);
        }

        /// <summary>
        /// 4th Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile4_2_Click(object sender, EventArgs e)
        {
            Tiles(6);
        }

        /// <summary>
        /// Platinum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile5_Click(object sender, EventArgs e)
        {
            Tiles(7);
        }

        /// <summary>
        /// 6th
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile6_Click(object sender, EventArgs e)
        {
            Tiles(8);
        }

        /// <summary>
        /// 7th 1.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile7_1_Click(object sender, EventArgs e)
        {
            Tiles(9);
        }

        /// <summary>
        /// 7th 1.5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile7_2_Click(object sender, EventArgs e)
        {
            Tiles(10);
        }

        /// <summary>
        /// 7th 2.0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile7_3_Click(object sender, EventArgs e)
        {
            Tiles(11);
        }

        /// <summary>
        /// CV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile8_Click(object sender, EventArgs e)
        {
            Tiles(12);
        }

        /// <summary>
        /// BERA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile9_Click(object sender, EventArgs e)
        {
            Tiles(13);
        }

        /// <summary>
        /// AEIC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile10_Click(object sender, EventArgs e)
        {
            Tiles(14);
        }

        /// <summary>
        /// EC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile11_Click(object sender, EventArgs e)
        {
            Tiles(15);
        }

        /// <summary>
        /// EV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile12_Click(object sender, EventArgs e)
        {
            Tiles(16);
        }

        /// <summary>
        /// NT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile13_1_Click(object sender, EventArgs e)
        {
            Tiles(17);
        }

        /// <summary>
        /// CV2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile13_2_Click(object sender, EventArgs e)
        {
            Tiles(18);
        }

        /// <summary>
        /// TT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTile14_Click(object sender, EventArgs e)
        {
            Tiles(19);
        }

        /// <summary>
        /// FN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroTile15_Click(object sender, EventArgs e)
        {
            Tiles(22);
        }

        /// <summary>
        /// 3S
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroTile16_Click(object sender, EventArgs e)
        {
            Tiles(23);
        }

        #endregion

        /// <summary>
        /// 탭 클릭 번호
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_Click(object sender, EventArgs e)
        {
            m_iSelect = tabControl.SelectedIndex;
        }

        /// <summary>
        /// 볼륨 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Volume_ValueChanged(object sender, EventArgs e)
        {
            m_iVolume = metroTrackBar_Volume.Value;
            // metroProgressBar_Volume.Value = Convert.ToInt32(metroTrackBar_Volume.Value * 0.98) + 2;
        }

        /// <summary>
        /// 밝기 조절
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTrackBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            m_iBrightness = metroTrackBar_Brightness.Value;
            // metroProgressBar_Brightness.Value = Convert.ToInt32(metroTrackBar_Brightness.Value * 0.98) + 2;

            SetBrightness(m_iBrightness);
        }

        /// <summary>
        /// 출처 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            form4.ShowDialog();
        }

        /// <summary>
        /// 정지 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_Stop_Click(object sender, EventArgs e)
        {
            Stop();

            // Flag 초기화
            for (int i = 0; i < m_bFlag.Length; i++)
            {
                m_bFlag[i] = true;
            }

            Tiles(-1);
        }

        /// <summary>
        /// WHITE OUT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton_WhiteOut_Click(object sender, EventArgs e)
        {
            Tiles(20);
        }

        /// <summary>
        /// Nothpole
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroButton_Northpole_Click(object sender, EventArgs e)
        {
            Tiles(21);
        }
    }
}
