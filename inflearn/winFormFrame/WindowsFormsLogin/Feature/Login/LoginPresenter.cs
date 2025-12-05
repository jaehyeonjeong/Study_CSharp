using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Base;

namespace WindowsFormsLogin.Feature.Login
{
    public class LoginPresenter : PresenterBase<ILoginView>
    {
        public override void Initialize()
        {
            View.OnLogin += View_OnLogin; // 델리게이트 이벤트 구독, 이벤트 핸들러 메서드 연결
        }

        private void View_OnLogin()    // View에서 Present로 호출되는 구간
        {
            View.ShowMessage($"UserId: {View.UserId}, Password: {View.Password}");
        }
    }
}
