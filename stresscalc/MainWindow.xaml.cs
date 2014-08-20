using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace stresscalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double _currentValue;
        private bool _operationUsed;

        private enum Sign
        {
            Null,

            [Description("+")]
            Plus,

            [Description("-")]
            Minus,

            [Description("*")]
            Multiply,

            [Description("/")]
            Divide
        }

        private Sign _sign;

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Length <= 7)
            {
                object buttonNumber = ((Button)e.Source).Content;


                screen.Text = screen.Text + buttonNumber;
                trace.Text = trace.Text + buttonNumber;
                back.IsEnabled = true;
                _operationUsed = false;
            }
            
            
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Length <= 7 && screen.Text.Length > 0)
            {
                object buttonNumber = ((Button)e.Source).Content;


                screen.Text = screen.Text + buttonNumber;
                trace.Text = trace.Text + buttonNumber;
                back.IsEnabled = true;
                _operationUsed = false;
            }
            else
            {
                object buttonNumber = ((Button)e.Source).Content;


                screen.Text = screen.Text + "0" + buttonNumber;
                trace.Text = trace.Text + "0" + buttonNumber;
                back.IsEnabled = true;
                _operationUsed = false;
            }

            point.IsEnabled = false;

        }
        
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
            trace.Text = "";
            _currentValue = 0;
            point.IsEnabled = true;

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            ExecuteMathOperation(e, Sign.Plus);
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            ExecuteMathOperation(e, Sign.Minus);
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            ExecuteMathOperation(e, Sign.Multiply);
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            ExecuteMathOperation(e, Sign.Divide);
        }

        private void ExecuteMathOperation(RoutedEventArgs e, Sign operationSign)
        {
            MakeCount();

            WritingTheOnlyMathOperation();

            _sign = operationSign;

            SaveStateAndClearScreen(e);
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            _sign = Sign.Null;

            SaveStateAndClearScreen(e);
            screen.Text = _currentValue.ToString(CultureInfo.InvariantCulture);
            trace.Text = _currentValue.ToString(CultureInfo.InvariantCulture);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text.Length > 1)
                screen.Text = screen.Text.Substring(0, screen.Text.Length - 1);
            else
            {
                screen.Text = "";
                back.IsEnabled = false;
            }

            trace.Text = trace.Text.Substring(0, trace.Text.Length - 1);
        }

        private void WritingTheOnlyMathOperation()
        {
            if (_operationUsed)
                trace.Text = trace.Text.Substring(0, trace.Text.Length - 1);
            _operationUsed = true;
        }

        private void MakeCount()
        {
            double inputValue;

            back.IsEnabled = false;
            point.IsEnabled = true;

            if (double.TryParse(screen.Text, out inputValue))
            {
                switch (_sign)
                {
                    case Sign.Minus:
                        _currentValue = Substract(_currentValue, inputValue);
                        break;
                    case Sign.Plus:
                        _currentValue = Add(_currentValue, inputValue);
                        break;
                    case Sign.Multiply:
                        _currentValue = Multiply(_currentValue, inputValue);
                        break;
                    case Sign.Divide:
                        double result;

                        if (TryDivide(_currentValue, inputValue, out result))
                            _currentValue = result;
                        else
                            MessageBox.Show("Division by zero");

                        break;

                    case Sign.Null:
                        _currentValue = inputValue;
                        break;
                }
            }
        }

        private bool TryDivide(double firstNumber, double secondNumber, out double result)
        {
            if (secondNumber != 0)
            {
                result = firstNumber/secondNumber;

                return true;
            }

            result = 0;

            return false;
        }

        private double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private double Substract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        private void SaveStateAndClearScreen(RoutedEventArgs e)
        {
            trace.Text = trace.Text + ((Button)e.Source).Content;
            screen.Text = "";
            showme.Content = _currentValue;
        }
        
    }
}
