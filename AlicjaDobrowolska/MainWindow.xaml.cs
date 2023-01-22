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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

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
            pokaz();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ");
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializacja.SerializeToXml<List<Movies>>(listOfMovies, "C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
        }
        public bool IsValid()
        {
            if (title_txt.Text == string.Empty || discount_txt.Text == string.Empty || seat_txt.Text == string.Empty)
            {
                MessageBox.Show("Wypełnij wszystkie dane", "Błąd zamówienia", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    SqlCommand command2 = new SqlCommand("Insert into Cinemat values(@title, @discount, @seat)", cnn);
                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@title", title_txt.Text);
                    command2.Parameters.AddWithValue("@discount", discount_txt.Text);
                    command2.Parameters.AddWithValue("@seat", seat_txt.Text);
                    cnn.Open();
                    command2.ExecuteNonQuery();
                    cnn.Close();
                    pokaz();
                    MessageBox.Show("Dodano", "Saved",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

        public void pokaz()
        {
            //wyswietlanie
            SqlConnection cnn = new SqlConnection(@"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ");
            

            SqlCommand command = new SqlCommand("select * from Cinemat", cnn);
            DataTable db = new DataTable();
            cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            db.Load(reader);
            cnn.Close();
            dataGridMovies.ItemsSource = db.DefaultView;
            //dataGridMovies.ItemsSource = listOfMovies;
            //if (File.Exists("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml"))
            //{
            //    listOfMovies = Serializacja.DeserializeToObject<List<Movies>>("C:\\Users\\laten\\OneDrive\\Pulpit\\test.xml");
            //}
            //else
            //{
            //    listOfMovies.Add(new Movies("Title", "Discount", "1"));
            //    listOfMovies.Add(new Movies("Title", "Discount", "2"));
            //    listOfMovies.Add(new Movies("Title", "Discount", "3"));
            //    listOfMovies.Add(new Movies("Title", "Discount", "4"));
            //}
            //dataGridMovies.ItemsSource = listOfMovies;
        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            
            //MessageBox.Show("Connection Open!");
            //cnn.Close();
            
            
            

            

            //command2.Dispose();
            
            ////update
            //SqlCommand command3;
            //SqlDataAdapter adapter2 = new SqlDataAdapter();
            //String sql3 = "";
            //sql3 = "Update Cinemat set title='" + "Obcy" + "' where Id=10";
            //command3 = new SqlCommand(sql3, cnn);
            //adapter2.UpdateCommand = new SqlCommand(sql3, cnn);
            //adapter2.UpdateCommand.ExecuteNonQuery();
            //command3.Dispose();

            ////deleting
            //SqlCommand command4;
            //SqlDataAdapter adapter3 = new SqlDataAdapter();
            //String sql4 = "Delete Cinemat where Id=10";
            //command4 = new SqlCommand(sql4, cnn);
            //adapter3.DeleteCommand = new SqlCommand(sql4, cnn);
            //adapter3.DeleteCommand.ExecuteNonQuery();
            //command4.Dispose();

            //cnn.Close();
        }

        public void usun()
        {

        }

        private void Button_Usun(object sender, RoutedEventArgs e)
        {
            cnn.Open();
            SqlCommand command = new SqlCommand("delete from cinemat where Id = " + search_txt.Text + " ", cnn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Usunięto", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                cnn.Close();
                pokaz();
                cnn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Nie usunięto" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            cnn.Open();
            SqlCommand command = new SqlCommand("update Cinemat set title = '" + title_txt.Text + "', discount = '"+discount_txt.Text+"', seat = '"+seat_txt.Text+"' WHERE Id = '"+search_txt.Text+"' ", cnn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Edytowano", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Nie edytowano" + ex.Message);
            }
            finally
            {
                cnn.Close();
                pokaz();
            }
        }
    }
}
