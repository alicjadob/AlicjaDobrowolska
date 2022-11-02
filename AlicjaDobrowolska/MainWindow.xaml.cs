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

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class kalkulator : Window
    {
        double first;
        double second;
        char op;

        public kalkulator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Text += btn.Content.ToString();
            second = float.Parse(textBox1.Text);

        }

        private void Button_C(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        private void Button_plus(object sender, RoutedEventArgs e)
        {
            first = float.Parse(textBox1.Text);
            op = '+';
            textBox1.Clear();
        }

        private void Button_minus(object sender, RoutedEventArgs e)
        {
            first = float.Parse(textBox1.Text);
            op = '-';
            textBox1.Clear();
        }

        private void Button_div(object sender, RoutedEventArgs e)
        {
            first = float.Parse(textBox1.Text);
            op = '/';
            textBox1.Clear();
        }

        private void Button_mult(object sender, RoutedEventArgs e)
        {
            first = float.Parse(textBox1.Text);
            op = '*';
            textBox1.Clear();
        }

        private void Button_equals(object sender, RoutedEventArgs e)
        {
            second = float.Parse(textBox1.Text);

            double result = 0;

            if(op == '+')
            {
                result = first + second;
                first = result;
            }
            else if (op == '-')
            {
                result = first - second;
                first = result;
            }
            else if (op == '*')
            {
                result = first * second;
                first = result;
            }
            else if (op == '/')
            {
                result = first / second;
                first = result;
            }
            if(textBox1.Text=="0")
            {
                textBox1.Clear();
            }
            
            textBox1.Text = result.ToString();
        }

        
    }
}
