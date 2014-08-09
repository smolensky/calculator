using System;
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
            
            trace.Content = trace.Content + "+";
            _preresult = _preresult + Convert.ToInt32(screen.Text);
            screen.Text = "";
            showme.Content = Convert.ToString(_preresult);
            
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
