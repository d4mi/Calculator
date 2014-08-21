using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public class CalculatorState
    {
        public string CurrentValue { get; private set; }
        public Stack<Value> Stack { get; private set; }

        public CalculatorState(string currentValue, Stack<Value> stack)
        {
            CurrentValue = currentValue;
            Stack = stack;
        }
    }
}
