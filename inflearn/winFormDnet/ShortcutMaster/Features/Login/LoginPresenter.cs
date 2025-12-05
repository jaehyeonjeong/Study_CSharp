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
        // View는 PresenterBase에서 필드로 상속받아 사용
        public override void Initialize()   // 상속 메소드에서 구현
        {
            View.OnLogin += View_OnLogin; // 델리게이트 이벤트 구독, 이벤트 핸들러 메서드 연결
        }

        private void View_OnLogin()    // View에서 Present로 호출되는 구간
        {
            View.ShowMessage($"UserId: {View.UserId}, Password: {View.Password}");
        }
    }
}
