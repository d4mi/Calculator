using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common
{
    public class OperationSelectedEventArgs : EventArgs
    {
        private string operation;

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public OperationSelectedEventArgs(string newOperation)
        {
            operation = newOperation;
        }      
    }
}
