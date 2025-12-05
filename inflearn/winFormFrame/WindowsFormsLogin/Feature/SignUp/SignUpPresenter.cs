using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Base;

// .NetFramework의 한계점 : record를 수동으로 만들어서 코드 추가가 많아짐
namespace WindowsFormsLogin.Feature.SignUp
{
    public class SignUpPresenter : PresenterBase<ISignUpView, SignUpArgs>
    {
        private SignUpViewModel _viewModel = new SignUpViewModel();
        public override void Initialize(SignUpArgs args)
        {
            View.OnUserIdChanged += View_OnUserIdChanged;
            View.OnUserPwChanged += View_OnUserPwChanged;
            View.OnUserPwConFirmChanged += View_OnUserPwCornFirmChanged;
            View.OnUserEmailChanged += View_OnUserEmailChanged;
            View.OnSignUpClicked += View_OnSignUpClicked;

            View.UserId = args.UserId;
            View.Password = args.Password;

            //View.ShowMessage($"UserID : {args.UserId}, Password : {args.Password}");
        }

        private void View_OnSignUpClicked()
        {
            // .NetFramework만의 Valid 검증 방법
            var context = new ValidationContext(_viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(_viewModel, context, results, validateAllProperties: true);

            if (!isValid)
            {
                // 여러 에러 메시지를 합쳐서 출력
                string errorMessages = string.Join("\n", results.Select(r => r.ErrorMessage));
                View.ShowMessage(errorMessages);
            }
            else
            {
                View.ShowMessage("회원가입 검증 성공!");
                // 실제 회원가입 로직 실행
            }
        }

        private void View_OnUserEmailChanged()
        {
            _viewModel = _viewModel.With(email: View.Email);
            Debug.Print(_viewModel.ToString());
        }

        private void View_OnUserPwCornFirmChanged()
        {
            _viewModel = _viewModel.With(confirmPassword: View.ConfirmPassword);
            Debug.Print(_viewModel.ToString());
        }

        private void View_OnUserPwChanged()
        {
            _viewModel = _viewModel.With(password: View.Password);
            Debug.Print(_viewModel.ToString());
        }

        private void View_OnUserIdChanged()
        {
            _viewModel = _viewModel.With(userId: View.UserId);
            Debug.Print(_viewModel.ToString());
        }
    }
}
