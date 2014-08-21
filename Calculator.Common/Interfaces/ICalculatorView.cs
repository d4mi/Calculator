using Calculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View.Interfaces
{
    public interface ICalculatorView : IView
    {
        event EventHandler<OperationSelectedEventArgs> OperationSelected;
        void UpdateExpressionLabel(string expression);
        void SetStack(int number, string value);
    }
}
