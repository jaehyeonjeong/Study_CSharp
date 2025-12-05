using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.SignUp
{
    public record SignUpViewModel(
        string UserId = "", 
        string Password = "", 
        string ConfirmPassword = "", 
        string Email = "");

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
