using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.Login
{
  public class LoginPresenter : PresenterBase<ILoginView>
  {  
    public override void Initialize()
    {
      View.OnLogin += View_OnLogin;
    }

    private void View_OnLogin()
    {
      View.ShowMessage($"UserId: {View.UserId}, Password: {View.Password}");
    }
  }
}
