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
    TPresenter Create<TView, TPresenter>(TView view)
      where TView : IView
      where TPresenter : PresenterBase<TView>;
  }

  public class PresenterFactory : IPresenterFactory
  {
    private readonly IServiceProvider _services;

    public PresenterFactory(IServiceProvider services)
    {
      this._services = services;
    }

    public TPresenter Create<TView, TPresenter>(TView view)
      where TView : IView
      where TPresenter : PresenterBase<TView>
    {
      TPresenter presenter = _services.GetRequiredService<TPresenter>();
      presenter.SetView(view);
      presenter.Initialize();
      return presenter;
    }
  }
}
