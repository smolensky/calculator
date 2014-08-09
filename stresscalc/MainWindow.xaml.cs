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
            if (_sign == Sign.Plus)
                _preresult = _preresult + Convert.ToInt32(screen.Text);
            else
                _preresult = Convert.ToInt32(screen.Text);

            _sign = Sign.Plus;


            trace.Content = trace.Content + "+";
            screen.Text = "";
            showme.Content = _preresult;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Make work for other signs - i.e. plus, multilpy, divide
            if (_sign != Sign.Null)
                MakeCount();
            else
                _preresult = Convert.ToInt32(screen.Text);

            _sign = Sign.Minus;


            trace.Content = trace.Content + "-";
            screen.Text = "";
            showme.Content = _preresult;
        }

        private void MakeCount()
        {
            switch (_sign)
            {
                case Sign.Minus:
                    _preresult = _preresult - Convert.ToInt32(screen.Text);
                    break;
                case Sign.Plus:
                    _preresult = _preresult + Convert.ToInt32(screen.Text);
                    break;
            }
            
        }
    }
}
