using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }



        private void button_click(object sender, EventArgs e)
        {

            if ((tbxResult.Text == "0") || (isOperationPerformed))
                tbxResult.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if(button.Text == ".")
            {
                if (!tbxResult.Text.Contains("."))
                tbxResult.Text = tbxResult.Text + button.Text;
            }
            else
            tbxResult.Text = tbxResult.Text + button.Text;
        }



        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEquality.PerformClick();
                operationPerformed = button.Text;
                lblCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(tbxResult.Text);
                lblCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;

            }
        }



        private void btnClearAll_Click(object sender, EventArgs e)
        {
            tbxResult.Text = "0";
            resultValue = 0;
        }



        private void btnClear1_Click(object sender, EventArgs e)
        {
            tbxResult.Text = "0";
        }



        private void btnEquality_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    tbxResult.Text = (resultValue + Double.Parse(tbxResult.Text)).ToString();
                    break;

                case "-":
                    tbxResult.Text = (resultValue - Double.Parse(tbxResult.Text)).ToString();
                    break;

                case "*":
                    tbxResult.Text = (resultValue * Double.Parse(tbxResult.Text)).ToString();
                    break;

                case "/":
                    tbxResult.Text = (resultValue / Double.Parse(tbxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(tbxResult.Text);
            lblCurrentOperation.Text = "";

        }

        
    }
}
