using Calculator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Presenter
{
    public abstract class PresenterBase<TView> : IPresenter
        where TView : IView
    {
        private TView view;

        public TView View
        {
            get { return view; }
            set { view = value; }
        }

        protected virtual void OnViewLoaded()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
