using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.Base
{
    public abstract class PresenterBase <TView> 
        where TView : IView // 제네릭 타입 TView는 IView 인터페이스를 구현해야 함
    {
        // 단일 추상화 클래스 구현
        public TView View { get; private set; } = default!; // 뷰 속성, 외부에서 설정 불가

        public void SetView(TView view) // 뷰 설정 메서드
        {
            View = view;
        }

        public virtual void Initialize() // 초기화 메서드, 필요시 오버라이드 가능
        {
        }
    }

    public abstract class PresenterBase<TView,TArgs> : PresenterBase<TView>
        where TView : IView     // 상속한 클래스에 where 조건 동일 
        where TArgs : class     
    {
        // 클래스를 사용한다는건 반드시 인자가 존재해야 됨
        public abstract void Initialize(TArgs args);    // 단일 추상화
    }    
}
