using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

// .NetFramework의 한게점 : record 클래스 사용불가
namespace WindowsFormsLogin.Feature.SignUp
{
    public class SignUpViewModel
    {
        public string UserId { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }
        public string Email { get; }

        public SignUpViewModel()
        {
            
        }
        public SignUpViewModel(string userId, string password, string confirmPassword, string email)
        {
            UserId = userId;
            Password = password;
            ConfirmPassword = confirmPassword;
            Email = email;
        }

        // Copy 메서드: 일부 속성만 변경 가능
        public SignUpViewModel With(
            string userId = null,
            string password = null,
            string confirmPassword = null,
            string email = null)
        {
            return new SignUpViewModel(
                userId ?? this.UserId,
                password ?? this.Password,
                confirmPassword ?? this.ConfirmPassword,
                email ?? this.Email
            );
        }

        // ToString 오버라이드 (record처럼 보기 좋게 출력)
        public override string ToString()
        {
            return $"SignUpViewModel {{ UserId = {UserId}, Password = {Password}, ConfirmPassword = {ConfirmPassword}, Email = {Email} }}";
        }
    }
}

