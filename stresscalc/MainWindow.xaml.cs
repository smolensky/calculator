using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace stresscalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int preresult;

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "0";
            trace.Content = trace.Content + "0";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "1";
            trace.Content = trace.Content + "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "2";
            trace.Content = trace.Content + "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "3";
            trace.Content = trace.Content + "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "4";
            trace.Content = trace.Content + "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "5";
            trace.Content = trace.Content + "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "6";
            trace.Content = trace.Content + "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "7";
            trace.Content = trace.Content + "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "8";
            trace.Content = trace.Content + "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "9";
            trace.Content = trace.Content + "9";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
            trace.Content = "";
            preresult = 0;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            
            trace.Content = trace.Content + "+";
            preresult = preresult + Convert.ToInt32(screen.Text);
            screen.Text = "";
            showme.Content = Convert.ToString(preresult);
            
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
