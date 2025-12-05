using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.SignUp
{
    public class SignUpPresenter : PresenterBase<ISignUpView, SignUpArgs>
    {
        public override void Initialize(SignUpArgs args)
        {
            View.ShowMessage($"UserId : {args.UserId}, Password : {args.Password}");
        }
    }
}
