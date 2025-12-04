using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Button btn = uc1.GetButton();
            uc1.Label1Text = "Hello UserControl!";
            string uc1label =uc1.Label1Text;
            MessageBox.Show(uc1label);

            uc2.Label1Text = "Hello uc2!";
            //string uc2label = uc2.Label1Text;
            //MessageBox.Show(uc2label);

            uc1.MyClick += new EventHandler(MyFunc1); //uc1에서만 동작
        }

        private void MyFunc1(object sender, EventArgs e)
        {
            MessageBox.Show("함수");
        }
    }
}
