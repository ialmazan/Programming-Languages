using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
Ivan Almazan
Assignment: Forms
*/

namespace Calculator
{
    public partial class Form1 : Form
    {
        private enum calculation { equals, add, subtract, multiply, divide, modulo}
        private int symbol = (int)calculation.equals;
        private bool check = true;
        private double firstNum = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string number = clickedButton.Text;

            inputNumber(number);
        }

        private void inputNumber(string number)
        {
            if (check)
                textBox.Text = number;
            else
                textBox.Text += number;
            check = false;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (symbol != (int)calculation.equals)
                evaluate();
            double.TryParse(textBox.Text, out firstNum);

            Button buttonClicked = (Button)sender;
            setsymbol(buttonClicked.Text);

            check = true;
        }

        private void setsymbol(string newsymbol)
        {
            switch (newsymbol)
            {
                case "+":
                    symbol = (int)calculation.add;
                    break;
                case "-":
                    symbol = (int)calculation.subtract;
                    break;
                case "*":
                    symbol = (int)calculation.multiply;
                    break;
                case "/":
                    symbol = (int)calculation.divide;
                    break;
                case "%":
                    symbol = (int)calculation.modulo;
                    break;
            }
        }

        private void evaluate()
        {
            double secondNum;
            double.TryParse(textBox.Text, out secondNum);

            switch (symbol)
            {
                case (int)calculation.add:
                    textBox.Text = (firstNum + secondNum).ToString();
                    break;
                case (int)calculation.subtract:
                    textBox.Text = (firstNum - secondNum).ToString();
                    break;
                case (int)calculation.multiply:
                    textBox.Text = (firstNum * secondNum).ToString();
                    break;
                case (int)calculation.divide:
                    textBox.Text = (firstNum / secondNum).ToString();
                    break;
                case (int)calculation.modulo:
                    textBox.Text = (firstNum % secondNum).ToString();
                    break;
                case (int)calculation.equals:
                    textBox.Text = firstNum.ToString();
                    break;
            }

            format();
            symbol = (int)calculation.equals;
        }

        private void format()
        {
            double number;
            double.TryParse(textBox.Text, out number);
            textBox.Text = String.Format("{0:n}", number);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                Control[] found = this.Controls.Find("button" + e.KeyChar, false);
                if (found.Length > 0)
                {
                    Button button = (Button)found[0];
                    button.PerformClick();
                }
            }
            else
            {
                switch (e.KeyChar)
                {
                    case '+':
                        add.PerformClick();
                        break;
                    case '-':
                        subtract.PerformClick();
                        break;
                    case '*':
                        multiply.PerformClick();
                        break;
                    case '/':
                        divide.PerformClick();
                        break;
                    case '%':
                        modulo.PerformClick();
                        break;
                    case '.':
                        deci.PerformClick();
                        break;
                    case (char)Keys.Return:
                        equals.PerformClick();
                        break;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            symbol = (int)calculation.equals;
            firstNum = 0.0;
            check = true;
        }

        private void clearEntryButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            double.TryParse(textBox.Text, out firstNum);
            textBox.Text = Math.Sqrt(firstNum).ToString();
            format();
        }

    }
}