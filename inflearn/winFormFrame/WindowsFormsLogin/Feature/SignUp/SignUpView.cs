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
        event Action OnUserIdChanged;
        event Action OnUserPwChanged;
        event Action OnUserPwConFirmChanged;
        event Action OnUserEmailChanged;
        event Action OnSignUpClicked;

        string UserId { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; }
        string Email { get; }

        void FocusTextBox(string propertyName);
    }  
    public partial class SignUpView : Form, ISignUpView
    {
        public string UserId { get => txtId.Text.Trim().ToLower(); set => txtId.Text = value; }
        public string Password { get => txtPw.Text; set => txtPw.Text = value; }

        public string ConfirmPassword => txtPwCornFirm.Text;

        public string Email => txtEmail.Text.ToLower().Trim();

        public SignUpView()
        {
            InitializeComponent();
        }

        public event Action OnUserIdChanged = default;
        public event Action OnUserPwChanged = default;
        public event Action OnUserPwConFirmChanged = default;
        public event Action OnUserEmailChanged = default;
        public event Action OnSignUpClicked = default;

        // .NetFramework의 한계.. 인터페이스 내부 선언 불가
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult ShowDialog(string name, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(name, caption, buttons);
        }

        private void txtId_TextChanged(object sender, EventArgs e) => OnUserIdChanged?.Invoke();

        private void txtPw_TextChanged(object sender, EventArgs e) => OnUserPwChanged?.Invoke();

        private void txtPwCornFirm_TextChanged(object sender, EventArgs e) => OnUserPwConFirmChanged?.Invoke();

        private void txtEmail_TextChanged(object sender, EventArgs e) => OnUserEmailChanged?.Invoke();

        private void button1_Click(object sender, EventArgs e) => OnSignUpClicked?.Invoke();

        public void FocusTextBox(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(SignUpViewModel.UserId):
                    txtId.Focus(); 
                    break;
                case nameof(SignUpViewModel.Password):
                    txtPw.Focus();
                    break;
                case nameof(SignUpViewModel.ConfirmPassword):
                    txtPwCornFirm.Focus();
                    break;
                case nameof(SignUpViewModel.Email):
                    txtEmail.Focus();
                    break;
            }
        }
    }
}
