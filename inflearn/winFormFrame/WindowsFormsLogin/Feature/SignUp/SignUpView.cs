using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsLogin.Feature.Base;

namespace WindowsFormsLogin.Feature.SignUp
{
    public interface ISignUpView : IView     // 모든 뷰 인터페이스 상속
    {
    }  
    public partial class SignUpView : Form, ISignUpView
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        // .NetFramework의 한계.. 인터페이스 내부 선언 불가
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult ShowDialog(string name, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(name, caption, buttons);
        }
    }
}
