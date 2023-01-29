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

        public bool IsValid()
        {
            if (name_txt.Text == string.Empty || surname_txt.Text == string.Empty || title_txt.Text == string.Empty || seat_txt.Text == string.Empty)
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
                    SqlCommand command2 = new SqlCommand("Insert into Cinemat values(@name, @surname, @title, @seat)", cnn);
                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@name", name_txt.Text);
                    command2.Parameters.AddWithValue("@surname", surname_txt.Text);
                    command2.Parameters.AddWithValue("@title", title_txt.Text);
                    command2.Parameters.AddWithValue("@seat", seat_txt.Text);
                    cnn.Open();
                    command2.ExecuteNonQuery();
                    cnn.Close();
                    pokaz();
                    MessageBox.Show("Dodano", "Saved",MessageBoxButton.OK, MessageBoxImage.Information);
                    Wyczysc();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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
            SqlCommand command = new SqlCommand("update Cinemat set name = '"+name_txt.Text+"', surname = '"+surname_txt.Text+"', title = '"+title_txt.Text+"', seat = '"+seat_txt.Text+"' WHERE Id = '"+search_txt.Text+"' ", cnn);
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
                Wyczysc();
                pokaz();
            }
        }
        public void Wyczysc()
        {
            name_txt.Clear();
            surname_txt.Clear();
            title_txt.Clear();
            seat_txt.Clear();
        }
        private void Button_Wyczysc(object sender, RoutedEventArgs e)
        {
            Wyczysc();
        }
    }
}
