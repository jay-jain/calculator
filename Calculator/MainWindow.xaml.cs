using System;
using System.Windows;

namespace Calculator
{
    public enum Operator
    {
        Null,
        Add,
        Minus,
        Divide,
        Multiply,
        Root,
        Factorial
    }

    public partial class MainWindow
    {
        private double total = 0.0;
        private double currentValue = 0.0;
        private Operator current;

        public MainWindow()
        {
            InitializeComponent();			
		}

		private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Divide);
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Multiply);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            DisplayInput(button7.Content.ToString());
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button8.Content.ToString());
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button9.Content.ToString());
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Add);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button4.Content.ToString());
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button5.Content.ToString());
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button6.Content.ToString());
        }

        private void subtractButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Minus);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button1.Content.ToString());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button2.Content.ToString());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button3.Content.ToString());
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            txtDisplay.Text = Convert.ToString(total);
        }

        private void squareRootButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Root);
        }

        private void Calculate()
        {
            switch (current)
            {
                case Operator.Add:
                    total = total + currentValue;
                    break;
                case Operator.Minus:
                    total = total - currentValue;
                    break;
                case Operator.Divide:
                    total = total / currentValue;
                    break;
                case Operator.Multiply:
                    total = total * currentValue;
                    break;
                case Operator.Root:
                    if(currentValue >= 0){
                        total = Math.Sqrt(total);                        
                    }else{
                        break;
                    }
                    break;
                case Operator.Factorial:
                    //if(currentValue > 1)
                    int cur = (int)currentValue;
                    
                    for(int i= cur - 1; i >= 1;i--)
                        {
                        cur = cur * i;
                        }
                    total = cur;
                    break;
                case Operator.Null:
                    break;
            }
            currentValue = 0;
            current = Operator.Null;
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
			DisplayInput(button0.Content.ToString());
        }

        private void decimalb_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + '.';
        }

        private void clearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = String.Empty;
		}

		private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            current = Operator.Null;
            txtDisplay.Clear();
            total = 0;
        }

        private void ApplyOperator(Operator op)
        {
            if (current != Operator.Null)
            {
                Calculate();
            }
            else
            {
                try
                {
                    total = double.Parse(txtDisplay.Text);
                }catch(System.FormatException e){
                    current = Operator.Null;
                }
            }
            txtDisplay.Clear();
            current = op;
        }

        private void DisplayInput(String n)
        {
            txtDisplay.Text = txtDisplay.Text + n;
            Double.TryParse(txtDisplay.Text, out currentValue);
        }

        private void factorialButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOperator(Operator.Factorial);
            txtDisplay.Text = txtDisplay.Text + '!';
        }
    }
}
