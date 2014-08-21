using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.View.Interfaces;
using Calculator.Presenter;
using Calculator.Common;

namespace Calculator.View
{
    public partial class CalculatorView : UserControl, ICalculatorView
    {
        #region Fields
      
        private CalculatorPresenter calculatorPresenter;

        #endregion

        #region Ctor

        public CalculatorView()
        {
            InitializeComponent();       

            calculatorPresenter = new CalculatorPresenter();
            calculatorPresenter.View = this;
            calculatorPresenter.Init();
        }

        #endregion

        #region GUI

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.Parent.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
        }
        
        private void buttonClick(object sender, MouseEventArgs e)
        {
            SendOperationSelected(((Button)sender).Text);
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendOperationSelected(e.KeyChar.ToString());
        }

        private void SendOperationSelected(string operation)
        {
            if (OperationSelected != null)
            {
                OperationSelected(this, new OperationSelectedEventArgs(operation));
            }
        }

        #endregion

        #region ICalculatorView

        public event EventHandler<OperationSelectedEventArgs> OperationSelected;

        public void UpdateExpressionLabel(string expression)
        {
            this.expressionLabel.Text = expression;
            this.expressionLabel.Refresh();
        }

        public void SetStack(int number, string value)
        {
            Label label = Controls.Find("StackLabel" + number.ToString(), true).FirstOrDefault() as Label;
            if (label != null)
            {
                label.Text = value;
            }
        }

        #endregion // ICalculatorView

    }
}
