using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 이 함수는 응용프로그램이 사용자 눈에 보이기전에 처리할 이벤트 함수이다.
        private void Form1_Load(object sender, EventArgs e)
        {
            // 폼 상의 위젯의 텍스트를 변경
            lbl1.Text = "글자입니다.";
            lbl2.Text = "2번째 글자 입니다.";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 버튼이 클릭 되었을 때 동작하는 함수에 해당
            lbl3.Text = "글자 3으로 변경되었습니다.";
        }

        private void btn2evt_Click(object sender, EventArgs e)
        {
            lbl4.Text = "글자 3로 변경되었습니다.";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                lbl4.Text = "체크 박스의 체크 확인";
                MessageBox.Show("메세지 박스 출력");   
                // System.Window.Form 이라는 라이브러리가 추가가 되어있기 때문에 클래스들을 사용할 수 있음
            } 
            else
            {
                lbl4.Text = "체크 해제 확인";
            }
        }
    }
}
