using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutMaster.Features.Base
{
  public abstract class PresenterBase<TView>
    where TView : IView
  {
    public TView View { get; private set; } = default!;

    public void SetView(TView view)
    {
      View = view;
    }

    public virtual void Initialize() { }
  }
}
