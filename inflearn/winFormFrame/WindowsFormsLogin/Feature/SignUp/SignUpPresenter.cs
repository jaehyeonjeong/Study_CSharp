using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Base;

namespace WindowsFormsLogin.Feature.SignUp
{
    public class SignUpPresenter : PresenterBase<ISignUpView, SignUpArgs>
    {
        public override void Initialize(SignUpArgs args)
        {
            View.ShowMessage($"UserID : {args.UserId}, Password : {args.Password}");
        }
    }
}
