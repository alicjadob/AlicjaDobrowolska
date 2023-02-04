using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using Microsoft.VisualBasic;

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
        }

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
            MainWindow main = new MainWindow();

            try
            {
                if (IsValid())
                {
                    SqlCommand command2 = new SqlCommand("Insert into Cinemat values(@name, @surname, @title, @seat)", main.cnn);
                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@name", name_txt.Text);
                    command2.Parameters.AddWithValue("@surname", surname_txt.Text);
                    command2.Parameters.AddWithValue("@title", title_txt.Text);
                    command2.Parameters.AddWithValue("@seat", seat_txt.Text);
                    main.cnn.Open();
                    command2.ExecuteNonQuery();
                    main.cnn.Close();
                    main.dataGridMovies.Items.Refresh();
                    main.pokaz();
                    MessageBox.Show("Dodano", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Wyczysc();
                    main.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.cnn.Open();
            SqlCommand command = new SqlCommand("update Cinemat set name = '" + name_txt.Text + "', surname = '" + surname_txt.Text + "', title = '" + title_txt.Text + "', seat = '" + seat_txt.Text + "' WHERE Id = '" + search_txt.Text + "' ", main.cnn);
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
                main.dataGridMovies.Items.Refresh();
                main.cnn.Close();
                Wyczysc();
                main.pokaz();
                main.Show();
            }
        }
        public void Wyczysc()
        {
            search_txt.Clear();
            name_txt.Clear();
            surname_txt.Clear();
            title_txt.Clear();
            seat_txt.Clear();
        }


        private void Button_Wyczysc(object sender, RoutedEventArgs e)
        {
            Wyczysc();
        }

        private void Button_Usun(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.cnn.Open();
            SqlCommand command = new SqlCommand("delete from cinemat where Id = " + search_txt.Text + " ", main.cnn);
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Usunięto", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                main.cnn.Close();
                main.pokaz();
                main.cnn.Close();
                main.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nie usunięto" + ex.Message);
            }
            finally
            {
                main.cnn.Close();
            }
        }
    }
}
