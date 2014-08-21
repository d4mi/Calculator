using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    public interface IView : IDisposable
    {
        event EventHandler Load;
        event EventHandler Disposed;
    }
}
