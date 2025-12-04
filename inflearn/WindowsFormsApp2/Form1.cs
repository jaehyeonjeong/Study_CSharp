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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 폼 2를 보여주는 동작
            Form2 form2 = new Form2();
            form2.MdiParent = this; // form2의 부모창은 Form1
            form2.Show();       // MDI 설정을 하면 Form1안에서만 이동가능, 클릭 시 복수의 form2를 생성
            // MDI 멀티파트 도큐먼트 역할
        }
    }
}
