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
    }
}
