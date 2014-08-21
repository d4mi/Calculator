using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Common;
using Calculator.Model.Utils;

namespace Calculator.Model
{
    public class Calculator
    {
        #region Fields

        private Stack<Value> stack;

        #endregion

        #region Properties

        public Stack<Value> Stack
        {
            get
            {
                return stack;
            }
            set
            {
                stack = value;
            }
        }

        public string CurrentValue { get; set; }

        #endregion

        #region Ctor

        public Calculator()
        {
            stack = new Stack<Value>();                
        }

        #endregion

        #region Public methods

        public void Enter()
        {
            if (CurrentValue != "")
            {
                stack.Push(new Value(CurrentValue));
                CurrentValue = "";
            }
        }

        public void Drop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }
       
        public void Add()
        {
            Enter();

            if (stack.Count < 2)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            Value secondFromStack = stack.Pop();

            stack.Push(firstFromStack + secondFromStack);
        }

        public void Sub()
        {
            Enter();

            if (stack.Count < 2)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            Value secondFromStack = stack.Pop();

            stack.Push(secondFromStack - firstFromStack);
        }

        public void Mul()
        {
            Enter();

            if (stack.Count < 2)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            Value secondFromStack = stack.Pop();

            stack.Push(secondFromStack * firstFromStack);
        }


        public void Div()
        {
            Enter();

            if (stack.Count < 2)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            Value secondFromStack = stack.Pop();

            stack.Push(secondFromStack / firstFromStack);
        }

        public void Sqrt()
        {
            Enter();

            if (stack.Count < 1)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            firstFromStack.Sqrt();
            stack.Push(firstFromStack);
        }

        public void Inv()
        {
            Enter();

            if (stack.Count < 1)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            firstFromStack.Inv();
            stack.Push(firstFromStack);
        }

        public void Rev()
        {
            Enter();

            if (stack.Count < 1)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            firstFromStack.Rev();
            stack.Push(firstFromStack);
        }

        public void Pow()
        {
            Enter();

            if (stack.Count < 1)
            {
                throw new EmptyStackException();
            }

            Value firstFromStack = stack.Pop();
            firstFromStack.Pow(2);
            stack.Push(firstFromStack);
        }

        
        #endregion



    }
}
