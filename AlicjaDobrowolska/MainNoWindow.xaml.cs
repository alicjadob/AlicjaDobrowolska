using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AlicjaDobrowolska
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainNoWindow : Window
	{
		List<Movies> listOfMovies = new List<Movies>();

		public MainNoWindow()
		{
			InitializeComponent();
			if (File.Exists("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml"))
			{
				listOfMovies = Serializacja.DeserializeToObject<List<Movies>>("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
			}
			else
			{
				listOfMovies.Add(new Movies("Title", "Type"));
				listOfMovies.Add(new Movies("Title", "Type"));
				listOfMovies.Add(new Movies("Title", "Type"));
				listOfMovies.Add(new Movies("Title", "Type"));
			}
			dataGridMovies.ItemsSource = listOfMovies;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Serializacja.SerializeToXml<List<Movies>>(listOfMovies, "C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
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