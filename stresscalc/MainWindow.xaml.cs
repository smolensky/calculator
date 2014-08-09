using System;
using System.ComponentModel;
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
            object buttonNumber = ((Button)e.Source).Content;

            screen.Text = screen.Text + buttonNumber;
            trace.Content = trace.Content + buttonNumber.ToString();
        }
        
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
            trace.Content = "";
            _preresult = 0;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            
            //trace.Content = trace.Content + "+";
            //_preresult = _preresult + Convert.ToInt32(screen.Text);
            //screen.Text = "";
            //showme.Content = Convert.ToString(_preresult);

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
                    case Sign.Null:
                        _preresult = integerScreenValue;
                        break;
                }
            }
        }
    }
}
