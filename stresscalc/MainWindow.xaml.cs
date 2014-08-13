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

        private double _preresult;
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
            _preresult = 0;
            point.IsEnabled = true;

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            WritingTheOnlyMathOperation();

            _sign = Sign.Plus;

            SaveStateAndClearScreen(e);
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            WritingTheOnlyMathOperation();

            _sign = Sign.Minus;

            SaveStateAndClearScreen(e);
            
        }
        
        private void multi_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            WritingTheOnlyMathOperation();

            _sign = Sign.Multiply;

            SaveStateAndClearScreen(e);
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            WritingTheOnlyMathOperation();

            _sign = Sign.Divide;

            SaveStateAndClearScreen(e);
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            _sign = Sign.Null;

            SaveStateAndClearScreen(e);
            screen.Text = _preresult.ToString(CultureInfo.InvariantCulture);
            trace.Text = _preresult.ToString(CultureInfo.InvariantCulture);
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
            double integerScreenValue;

            back.IsEnabled = false;
            point.IsEnabled = true;

            if (double.TryParse(screen.Text, out integerScreenValue))
            {
                switch (_sign)
                {
                    case Sign.Minus:
                        _preresult = _preresult - integerScreenValue;
                        break;
                    case Sign.Plus:
                        _preresult = _preresult + integerScreenValue;
                        break;
                    case Sign.Multiply:
                        _preresult = _preresult * integerScreenValue;
                        break;
                    case Sign.Divide:
                        if (Math.Abs(integerScreenValue) > 0)
                            _preresult = _preresult / integerScreenValue;
                        else
                            MessageBox.Show("Division by zero");
                        break;
                    case Sign.Null:
                        _preresult = integerScreenValue;
                        break;
                }
            }
        }

        private void SaveStateAndClearScreen(RoutedEventArgs e)
        {
            trace.Text = trace.Text + ((Button)e.Source).Content;
            screen.Text = "";
            showme.Content = _preresult;
        }
        
    }
}
