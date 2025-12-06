using FluentValidation;
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
    public class SignUpPresenter: PresenterBase<ISignUpView, SignUpArgs>
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
            try
            {
                var validator = new SignUpViewModelValidator();
                validator.ValidateAndThrow(_viewModel);
            }
            catch (FluentValidation.ValidationException e)
            {
                var error = e.Errors.First();
                // 포커스를 가져다 줘야 할 속성에서 에러가 나는지 알기 위함
                View.FocusTextBox(error.PropertyName);
                View.ShowMessage(error.ErrorMessage);
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
