using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutMaster.Features.SignUp
{
    public interface ISignUpView : IView
    {
        event Action OnUserIdChanged;
        event Action OnUserPwChanged;
        event Action OnUserPwCornFirmChanged;
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
        public SignUpView()
        {
            InitializeComponent();
        }

        public string UserId { get => txtId.Text.Trim().ToLower(); set => txtId.Text = value; }

        public string Password { get => txtPw.Text; set => txtPw.Text = value; }

        public string ConfirmPassword => txtPwConFirm.Text;

        public string Email => txtEmail.Text.ToLower().Trim();

        public event Action OnUserIdChanged = default!;
        public event Action OnUserPwChanged = default!;
        public event Action OnUserPwCornFirmChanged = default!;
        public event Action OnUserEmailChanged = default!;
        public event Action OnSignUpClicked = default!;

        private void txtId_TextChanged(object sender, EventArgs e) => OnUserIdChanged?.Invoke();
        private void txtPw_TextChanged(object sender, EventArgs e) => OnUserPwChanged?.Invoke();
        private void txtPwConFirm_TextChanged(object sender, EventArgs e) => OnUserPwCornFirmChanged?.Invoke();
        private void txtEmail_TextChanged(object sender, EventArgs e) => OnUserEmailChanged?.Invoke();
        private void btnSignUp_Click(object sender, EventArgs e)=>OnSignUpClicked?.Invoke();

        public void FocusTextBox(string propertyName)
        {
            // switch 안에 case가 리터럴 타입을 좋지 않음
            switch (propertyName)
            {
                case nameof(SignUpViewModel.UserId):
                    txtId.Focus();
                    break;
                case nameof(SignUpViewModel.Password):
                    txtPw.Focus();
                    break;
                case nameof(SignUpViewModel.ConfirmPassword):
                    txtPwConFirm.Focus();
                    break;
                case nameof(SignUpViewModel.Email):
                    txtEmail.Focus();
                    break;
            }
        }
    }
}
