using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("끝내기 클릭");
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("저장 클릭");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.nature_9899712_1920;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 라디오 버튼이 클릭이 되었는지를 확인하는 코드
            if (radioButton1.Checked)
            {
                MessageBox.Show("라디오 버튼 1 체크");
                // 코드를 적어서 실행할 수 있음
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            checkBox2.Checked = !checkBox2.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 일정한 시간간격마다 호출
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("대기중");
            }
            else if(textBox1.Text.Equals("asdf"))
            {
                MessageBox.Show("asdf를 삽입했습니다.");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("5초마다 출력");
        }
    }
}
