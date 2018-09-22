using System;
using System.Windows;


namespace Calculator
{
    // List of Operators
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
        // Declare and intialize some variables
        private double total = 0.0;
        private double currentValue = 0.0;
        private Operator current;

        public MainWindow()
        {
            InitializeComponent();			
		}

		private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            if (expression.Text == String.Empty) // Initial use of divide operator
            {
                expression.Text = txtDisplay.Text + '/';
                ApplyOperator(Operator.Divide);
            }
            else if (expression.Text[expression.Text.Length - 1] == '/') // When dividing with other division operators
            {
                expression.Text += txtDisplay.Text + '/';
                ApplyOperator(Operator.Divide);
            }
            else
            {
                expression.Text = expression.Text + txtDisplay.Text + '/'; // When dividing with multiple other operators
                ApplyOperator(Operator.Divide);
            }
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (expression.Text == String.Empty) // Initial use of multiply operator
            {
                expression.Text = txtDisplay.Text + '*';
                ApplyOperator(Operator.Multiply);
            } else if (expression.Text[expression.Text.Length - 1] == '*') // When multiplying with other multiplication operators
            {
                expression.Text += txtDisplay.Text +'*';
                ApplyOperator(Operator.Multiply);
            }
            else // When multipling with other various operators
            {
                expression.Text = expression.Text + txtDisplay.Text + '*';
                ApplyOperator(Operator.Multiply);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (expression.Text == String.Empty) // Initial use of addition operator
            {
                expression.Text = txtDisplay.Text + '+';
                ApplyOperator(Operator.Add);
            }
            else if (expression.Text[expression.Text.Length - 1] == '+') // When adding with other addition operators
            {
                expression.Text += txtDisplay.Text + '+';
                ApplyOperator(Operator.Add);
            }
            else // When adding with multiple other operators
            {
                expression.Text = expression.Text + txtDisplay.Text + '+';
                ApplyOperator(Operator.Add);
            }
        }

        private void subtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (expression.Text == String.Empty) // Initial use of subtract operator
            {
                expression.Text = txtDisplay.Text + '-';
                ApplyOperator(Operator.Minus);
            }
            else if (expression.Text[expression.Text.Length - 1] == '-') // When subtracting with other subtraction operators
            {
                expression.Text += txtDisplay.Text + '-';
                ApplyOperator(Operator.Minus);
            }
            else // When subtracting with multiple other operators
            {
                expression.Text = expression.Text + txtDisplay.Text + '-';
                ApplyOperator(Operator.Minus);
            }
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            txtDisplay.Text = Convert.ToString(total); 
            expression.Text = String.Empty;
        }

        private void squareRootButton_Click(object sender, RoutedEventArgs e)
        {
            expression.Text = "√" + txtDisplay.Text;
            ApplyOperator(Operator.Root);
        }

        private void factorialButton_Click(object sender, RoutedEventArgs e)
        {
            expression.Text = txtDisplay.Text + '!';
            ApplyOperator(Operator.Factorial);
        }

        /* Numerical button clicks*/
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

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            DisplayInput(button0.Content.ToString());
        }

        private void decimalb_Click(object sender, RoutedEventArgs e)
        {
            //expression.Text = expression.Text + '.';
            txtDisplay.Text = txtDisplay.Text + '.';
        }

        /* Perform various operations */
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
                    if (currentValue >= 0) {
                        total = Math.Sqrt(total);
                    } else {
                        break;
                    }
                    break;
                case Operator.Factorial:
                    currentValue = Convert.ToDouble(expression.Text.TrimEnd('!')); // Remove factorial operator in order to correctly obtain operand
                    Console.WriteLine("current value: " + currentValue);
                    if (currentValue == 0 || currentValue == 1){ // Base case
                        total = 1;
                        break;
                    }else if (currentValue >= 2 ) { // Positive integer cases
                        int cur = (int)currentValue;

                        for (int i = cur - 1; i >= 1; i--)
                        {
                            cur = cur * i;
                        }
                        total = cur;
                        break;
                    }
                    else if(currentValue < 0) // Negative integer cases
                    {
                        total = 99999999999;
                        break;
                    }
                    break;
                case Operator.Null:
                    break;
            }
            currentValue = 0; // Reset current value
            current = Operator.Null; // Reset current operator
        }



        private void clearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if(expression.Text != String.Empty) // Clear the bottom textbox when an expression is being constructed in the top text box
            {
                txtDisplay.Text = String.Empty;
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }

		private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            current = Operator.Null;
            txtDisplay.Text = "0";
            expression.Text = String.Empty;
            total = 0;
        }

        private void ApplyOperator(Operator op)
        {
            if (current != Operator.Null)
            {
                Calculate();
            }
            else
            { // Error handling for null operator
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
            if(txtDisplay.Text == "0") // Reset bottom text box to input to avoid preceding zeroes
            {
                txtDisplay.Text = n;
                currentValue = Convert.ToDouble(txtDisplay.Text);
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + n;
                Double.TryParse(txtDisplay.Text, out currentValue);
            }
        }
    }
}
