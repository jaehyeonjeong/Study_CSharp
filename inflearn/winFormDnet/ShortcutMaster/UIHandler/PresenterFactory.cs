using Microsoft.Extensions.DependencyInjection;
using ShortcutMaster.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.UIHandler
{
    public interface IPresenterFactory
    {
        TPresenter Create<TView, TPresenter>(TView view) // TView와 TPresenter를 사용하여 프레젠터 생
            where TView : IView         // TView는 IView 인터페이스를 구현해야 함
            where TPresenter : PresenterBase<TView>;   
    }

    public class PresenterFactory : IPresenterFactory
    {
        private readonly IServiceProvider _service;

        public PresenterFactory(IServiceProvider service)
        {
            this._service = service;
        }
        public TPresenter Create<TView, TPresenter>(TView view)
            where TView : IView
            where TPresenter : PresenterBase<TView>
        {
            // 의존성 주입 컨테이너에서 TPresenter 인스턴스 생성
            TPresenter presenter = _service.GetRequiredService<TPresenter>();
            presenter.SetView(view); // 뷰 설정
            presenter.Initialize();  // 프레젠터 초기화
            return presenter; // 생성된 프레젠터 반환
        }
    }
}
