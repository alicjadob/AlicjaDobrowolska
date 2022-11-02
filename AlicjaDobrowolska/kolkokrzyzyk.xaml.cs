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
using System.Windows.Shapes;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Interaction logic for kolkokrzyzyk.xaml
    /// </summary>
    public partial class kolkokrzyzyk : Window
    {
        public kolkokrzyzyk()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
        }


        private void Button_Restart(object sender, RoutedEventArgs e)
        {

        }
    }
}
