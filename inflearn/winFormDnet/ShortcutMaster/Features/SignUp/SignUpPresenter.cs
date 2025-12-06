using FluentValidation;
using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.SignUp
{
    public class SignUpPresenter(IValidator<SignUpViewModel> _validator) : PresenterBase<ISignUpView, SignUpArgs>
    {
        private SignUpViewModel _viewModel = new();

        public override void Initialize(SignUpArgs args)
        {
            View.OnUserIdChanged += View_OnUserIdChanged;
            View.OnUserPwChanged += View_OnUserPwChanged;
            View.OnUserPwCornFirmChanged += View_OnUserPwCornFirmChanged;
            View.OnUserEmailChanged += View_OnUserEmailChanged;
            View.OnSignUpClicked += View_OnSignUpClicked;

            View.UserId = args.UserId;
            View.Password = args.Password;
        }

        private void View_OnSignUpClicked()
        {
            try
            {
                _validator.ValidateAndThrow(_viewModel);
            }
            catch (ValidationException e)
            {
                var error = e.Errors.First();
                // 포커스를 가져다 줘야 할 속성에서 에러가 나는지 알기 위함
                View.FocusTextBox(error.PropertyName);
                View.ShowMessage(error.ErrorMessage);

            }
        }

        private void View_OnUserEmailChanged()
        {
            _viewModel = _viewModel with { Email = View.Email };
            Debug.Print(_viewModel.ToString());
        }

        private void View_OnUserPwCornFirmChanged()
        {
            _viewModel = _viewModel with { ConfirmPassword = View.ConfirmPassword };
            Debug.WriteLine(_viewModel.ToString());
        }

        private void View_OnUserPwChanged()
        {
            _viewModel = _viewModel with { Password = View.Password };
            Debug.Print(_viewModel.ToString());
        }

        private void View_OnUserIdChanged()
        {
            _viewModel = _viewModel with { UserId = View.UserId };
            Debug.Print(_viewModel.ToString());
        }
    }
}
