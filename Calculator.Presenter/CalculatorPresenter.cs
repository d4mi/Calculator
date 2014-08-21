using Calculator.View;
using Calculator.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Model;
using Calculator.Common;
using Calculator.Model.Utils;

namespace Calculator.Presenter
{
    public class CalculatorPresenter : PresenterBase<ICalculatorView>
    {
        #region Fields

        private Calculator.Model.Calculator calculator;
        private Stack<CalculatorState> calculatorHistory;
        private Dictionary<string, Action> operationDictionary;
         
        #endregion // Fields

        #region Ctor

        public CalculatorPresenter()
        {
            calculator = new Calculator.Model.Calculator();
            calculatorHistory = new Stack<CalculatorState>();

            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            operationDictionary = new Dictionary<string, Action>()
            {
                { "+",     () => calculator.Add()   },
                { "-",     () => calculator.Sub()   },
                { "*",     () => calculator.Mul()   },
                { "/",     () => calculator.Div()   },
                { "^",     () => calculator.Pow()   },
                { "Sqrt",  () => calculator.Sqrt()  },
                { "1/x",   () => calculator.Inv()   },
                { "Enter", () => calculator.Enter() },
                { "Drop",  () => calculator.Drop()  },
                { "Undo",  () => this.Undo()        },
                { "+/-" ,  () => calculator.Rev()   }
            };
        }

        #endregion // Ctor

        #region Public methods

        public void Init()
        {
            this.View.OperationSelected += View_OperationSelected;
        }

        #endregion

        #region View updates

        private void View_OperationSelected(object sender, OperationSelectedEventArgs e)
        {
            AddToHistory();

            if (e.Operation.Length == 1)
            {
                char keyValue = Char.Parse(e.Operation);
                if (ValidKeyValue(keyValue))
                {
                    calculator.CurrentValue += keyValue;
                    UpdateCurrentValue();
                    return;
                }
            }

            try
            {
                if (operationDictionary.ContainsKey(e.Operation))
                {                    
                    operationDictionary[e.Operation]();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                calculatorHistory.Pop();
            }

            UpdateStack();
            UpdateCurrentValue();
        }

        private bool ValidKeyValue(char keyValue)
        {
            return (Char.IsNumber(keyValue) || keyValue == '.' || keyValue == ':');
        }

        private void UpdateCurrentValue()
        {            
            this.View.UpdateExpressionLabel(calculator.CurrentValue);
        }

        private void UpdateStack()
        {
            for (int index = 0; index < Config.StackSize; ++index)
            {
                if (index < calculator.Stack.Count)
                {
                    this.View.SetStack(index + 1, calculator.Stack.ElementAt(index).CurrentValue);
                }
                else
                {
                    this.View.SetStack(index + 1, "");
                }
            }
        }

        private void Undo()
        {
            calculatorHistory.Pop();
         
            if (calculatorHistory.Count > 0)
            {
                CalculatorState state = calculatorHistory.Pop();
                calculator.CurrentValue = state.CurrentValue;
                calculator.Stack = state.Stack;

                UpdateStack();
                UpdateCurrentValue();
            }
        }

        private void AddToHistory()
        {
            Stack<Value> stack = StackCopier.DeepCopyStack(calculator.Stack);
            calculatorHistory.Push(new CalculatorState(calculator.CurrentValue, stack));
        }

        #endregion
    }
}
