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
    public partial class UserControl1 : UserControl
    {
        // public을 안하면 기본은 private
        public EventHandler MyClick;

        public UserControl1()
        {
            InitializeComponent();
        }

        //public Button GetButton()       // 안좋은 설계
        //{
        //    return button1;
        //}

        // 많이 사용하는 방법
        // 속성 하나하나에 캡슐화
        public string Label1Text
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        // 한번 정의한 get, set은 여러 사용자 컨트롤에서 재사용 가능

        private void button3_Click(object sender, EventArgs e)
        {
            // 버튼의 이미지를 변경하는 나만의 컨트롤러
            button3.Image = Properties.Resources._20251120154630;

            EventHandler handler = MyClick;
            if(handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
