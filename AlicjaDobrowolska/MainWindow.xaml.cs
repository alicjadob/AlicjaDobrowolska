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
    public partial class MainWindow : Window
    {
        List<Movies> listOfMovies = new List<Movies>();
        public MainWindow()
        {
            InitializeComponent();
            listOfMovies.Add(new Movies("one", "xxxx"));
            listOfMovies.Add(new Movies("two", "yyyy"));
            listOfMovies.Add(new Movies("three", "zzzz"));
            dataGridMovies.ItemsSource = listOfMovies;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1();
            Movies filmy = new Movies();
            okno.DataContext = filmy;
            okno.ShowDialog();
            if (okno.IsEditPressed)
            {
                listOfMovies.Add(filmy);
                dataGridMovies.Items.Refresh();
            }
        }

        private void Button_Properties(object sender, RoutedEventArgs e)
        {
            if (dataGridMovies.SelectedItem != null)
            {
                Window1 okno = new Window1();
                Movies filmy = new Movies((Movies)dataGridMovies.SelectedItem);
                okno.DataContext = filmy;
                okno.ShowDialog();
                if (okno.IsEditPressed)
                {
                    int index = listOfMovies.IndexOf((Movies)dataGridMovies.SelectedItem);
                    listOfMovies[index] = filmy;
                    dataGridMovies.Items.Refresh();
                }
            }
        }
    }
}
