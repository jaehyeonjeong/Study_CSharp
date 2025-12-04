using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("message box1");
        }

        //private int button2_Click(object sender, EventArgs e)
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("message box2");
            //return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(button1_Click);       // 나중에 추가되는 이벤트
            // 왜냐.. Designer.cs에서 먼저 선언된 이벤트 설정 후 그 다음에 설정되기 때문 
        }
    }
}
