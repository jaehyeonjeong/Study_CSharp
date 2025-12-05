using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLogin.Feature.Base
{
    public abstract class PresenterBase<TView>
        where TView : IView
    {
        public TView View { get; private set; } = default;

        public void SetView(TView view)
        {
            View = view;
        }   

        public virtual void Initialize()
        {
        }   
    }
}
