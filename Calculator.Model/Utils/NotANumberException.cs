using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model.Utils
{
    [Serializable]
    public class NotANumberException : Exception
    {
        public NotANumberException()
            : base("Not a number")
        {
        }
    }
}
