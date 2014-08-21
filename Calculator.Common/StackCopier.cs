using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common
{
    public class StackCopier
    {
        public static Stack<T> DeepCopyStack<T>(Stack<T> stack) 
            where T : ICloneable
        {
            Stack<T> copiedStack = new Stack<T>();
            for (int i = 0; i < stack.Count; i++)
            {
                copiedStack.Push((T)stack.ElementAt(i).Clone());
            }
            return copiedStack;
        }
    }
}
