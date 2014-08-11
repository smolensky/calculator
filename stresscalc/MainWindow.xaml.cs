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

        private int _preresult;

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
                trace.Content = trace.Content + buttonNumber.ToString();
                back.IsEnabled = true;
            }
            
            
        }
        
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
            trace.Content = "";
            _preresult = 0;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Make work for other signs - i.e. plus, multilpy, divide
            MakeCount();
            
            _sign = Sign.Plus;

            SaveStateAndClearScreen(e);
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Make work for other signs - i.e. plus, multilpy, divide
            MakeCount();
            
            _sign = Sign.Minus;

            SaveStateAndClearScreen(e);
            
        }

        private void SaveStateAndClearScreen(RoutedEventArgs e)
        {
            trace.Content = trace.Content + ((Button) e.Source).Content.ToString();
            screen.Text = "";
            showme.Content = _preresult;
        }

        private void MakeCount()
        {
            int integerScreenValue;

            back.IsEnabled = false;

            if (Int32.TryParse(screen.Text, out integerScreenValue))
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
                        if (integerScreenValue != 0)
                            _preresult = _preresult/integerScreenValue;
                        else
                            MessageBox.Show("Division by zero");
                        
                        break;
                    case Sign.Null:
                        _preresult = integerScreenValue;
                        break;
                }
            }
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            _sign = Sign.Multiply;

            SaveStateAndClearScreen(e);
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            _sign = Sign.Divide;

            SaveStateAndClearScreen(e);
        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            MakeCount();

            _sign = Sign.Null;

            SaveStateAndClearScreen(e);
            screen.Text = _preresult.ToString(CultureInfo.InvariantCulture);
            trace.Content = _preresult.ToString(CultureInfo.InvariantCulture);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            //fix trace label bug
            if (screen.Text.Length > 1)
            {
                screen.Text = screen.Text.Substring(0, screen.Text.Length - 1);
                trace.Content = screen.Text;
            }
            else
            {
                screen.Text = "";
                trace.Content = "";
            }
        }
    }
}
