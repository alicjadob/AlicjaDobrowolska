using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            pokaz();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ");

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
                    MessageBox.Show("Dodano", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow okno = new MainWindow();
                    Movies movies = new Movies();
                    okno.DataContext = movies;
                    listOfMovies.Add(movies);
                    dataGridMovies.Items.Refresh();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            cnn.Open();
            SqlCommand command = new SqlCommand("update Cinemat set title = '" + title_txt.Text + "', discount = '" + discount_txt.Text + "', seat = '" + seat_txt.Text + "' WHERE Id = '" + search_txt.Text + "' ", cnn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Edytowano", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie edytowano" + ex.Message);
            }
            finally
            {
                cnn.Close();
                pokaz();
            }
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
            catch (SqlException ex)
            {
                MessageBox.Show("Nie usunięto" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
