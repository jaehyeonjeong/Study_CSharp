using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 알림창 띄우기
            MessageBox.Show(123 + "매개변수가 한계입니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 로그인 알림
            DialogResult dialogResult =  MessageBox.Show("로그인 하시겠습니까?", "로그인", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            // MessageBox 속성을 바꿀 수 있는 Enum 데이터로 속성 변경

            // 사용자가 확인을 눌렀을 때 if문
            if (DialogResult.OK == dialogResult)
            {
                // 사용자가 asdf로그인을 하였습니다. (메세지 박스)
                if(textBox1.Text.Equals("asdf"))
                {
                    MessageBox.Show("로그인이 성공적으로 되었습니다. ID : " + textBox1.Text); // 아이디 정보 출력
                }
                else
                {
                    MessageBox.Show("로그인을 실패하셨습니다. ID : " + textBox1.Text);
                }
            }
        }
    }
}
