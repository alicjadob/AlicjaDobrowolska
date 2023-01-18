using System;
using System.Collections.Generic;
using System.IO;
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
            if (File.Exists("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml"))
            {
                listOfMovies = Serializacja.DeserializeToObject<List<Movies>>("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
            }
            else
            {
                listOfMovies.Add(new Movies("Title", "Discount", "1"));
                listOfMovies.Add(new Movies("Title", "Discount", "2"));
                listOfMovies.Add(new Movies("Title", "Discount", "3"));
                listOfMovies.Add(new Movies("Title", "Discount", "4"));
            }
            dataGridMovies.ItemsSource = listOfMovies;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializacja.SerializeToXml<List<Movies>>(listOfMovies, "C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
        }
        private void Button_Zamow(object sender, RoutedEventArgs e)
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

        private void Button_Wlasciwosci(object sender, RoutedEventArgs e)
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
