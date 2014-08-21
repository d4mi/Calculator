using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.View
{
    public partial class Main : Form
    {
        private CalculatorView calculator;

        public Main()
        {
            InitializeComponent();
            calculator = new CalculatorView();
            Controls.Add(calculator);
        }
    }
}
