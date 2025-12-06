using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

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

    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("아이디를 입력해주세요.")
                .Length(4, 20).WithMessage("아이디는 4자 이상 20자 이하여야 합니다.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("비밀번호를 입력해주세요")
                .MinimumLength(4).WithMessage("비밀번호는 최소 4자 이상이어야 합니다.")
                .Matches("[A-Z]").WithMessage("비밀번호는 대문자를 하나 이상 포함해야 합니다.")
                .Matches("[a-z]").WithMessage("비밀번호는 소문자를 하나 이상 포함해야 합니다.")
                .Matches("[0-9]").WithMessage("비밀번호는 숫자를 하나 이상 포함해야 합니다.")
                .Matches("[^a-zA-Z0-9]").WithMessage("비밀번호는 특수문자를 하나 이상 포함해야 합니다.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("비밀번호가 일치하지 않습니다.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("이메일을 입력해주세요.")
                .EmailAddress().WithMessage("이메일 형식이 올바르지 않습니다.");
        }
    }
}

