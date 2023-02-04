using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pokaz();
        }
        public SqlConnection cnn = new SqlConnection(@"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ");

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }

        public void pokaz()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ");
            cnn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from [Cinemat]";
            command.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridMovies.ItemsSource = dt.DefaultView;
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }

        private void dataGridMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Window1 window1 = new Window1();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                window1.Show();
                window1.search_txt.Text = row_selected["Id"].ToString();
                window1.name_txt.Text = row_selected["name"].ToString();
                window1.surname_txt.Text = row_selected["surname"].ToString();
                window1.title_txt.Text = row_selected["title"].ToString();
                window1.seat_txt.Text = row_selected["seat"].ToString();
                Close();
            }
        }
    }
}
