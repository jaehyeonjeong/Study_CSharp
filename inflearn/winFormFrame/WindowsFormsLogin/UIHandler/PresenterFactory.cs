using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsLogin.Feature.Base;

namespace WindowsFormsLogin.UIHandler
{
    public interface IPresenterFactory
    {
        TPresenter Create<TView, TPresenter>(TView view)
            where TView :IView
            where TPresenter : PresenterBase<TView>;

        // 인자를 받을 수 있는 PresenterBase 추가
        TPresenter Create<TView, TPresenter, TArgs>(TView view, TArgs args)
            where TView : IView
            where TPresenter : PresenterBase<TView, TArgs>
            where TArgs : class;
    }

    public class PresenterFactory : IPresenterFactory
    {
        private readonly IServiceProvider _service;

        public PresenterFactory(IServiceProvider service)
        {
            _service = service;
        }

        public TPresenter Create<TView, TPresenter>(TView view)
            where TView : IView
            where TPresenter : PresenterBase<TView>
        {
            TPresenter presenter = _service.GetRequiredService<TPresenter>(); 
            presenter.SetView(view);
            presenter.Initialize();
            return presenter;
        }

        public TPresenter Create<TView, TPresenter, TArgs>(TView view, TArgs args)
            where TView : IView
            where TPresenter : PresenterBase<TView, TArgs>
            where TArgs : class
        {
            // 의존성 주입 컨테이너에서 TPresenter 인스턴스 생성
            TPresenter presenter = _service.GetRequiredService<TPresenter>();
            presenter.SetView(view); // 뷰 설정
            presenter.Initialize(args);  // args 파라미터 값으로 뷰 값 데이터 변환
            return presenter; // 생성된 프레젠터 반환
        }
    }
}
