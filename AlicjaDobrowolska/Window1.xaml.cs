using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
using static AlicjaDobrowolska.MainWindow;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsEditPressed { get; set; }
        public Window1()
        {
            InitializeComponent();
        }
       
        private void Button_Anuluj(object sender, RoutedEventArgs e)
        {
            IsEditPressed = false;
            this.Close();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            IsEditPressed = true;
            this.Close();
        }

        public bool IsValid()
        {
            if(title_txt.Text == string.Empty || discount_txt.Text == string.Empty || seat_txt.Text == string.Empty)
            {
                MessageBox.Show("Wypełnij wszystkie dane", "Błąd zamówienia", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            try()
                {
                if (IsValid())
                {
                    // insert
                    string connetionString;
                    SqlConnection cnn;
                    connetionString = @"Data Source=ALICJA\SQLEXPRESS;Initial Catalog=Cinema;Integrated Security=true ";
                    cnn = new SqlConnection(connetionString);
                    SqlCommand command2;
                    String sql2 = "Insert into Cinemat values(@title, @discount, @seat)";
                    command2 = new SqlCommand(sql2, cnn);
                    command2.CommandType = CommandType.Text;
                    command2.Parameters.AddWithValue("@title", title_txt.Text);
                    command2.Parameters.AddWithValue("@discount", discount_txt.Text);
                    command2.Parameters.AddWithValue("@seat", seat_txt.Text);
                    cnn.Open();
                    MainWindow pokaz = new MainWindow();
                    pokaz.pokaz();
                    //adapter.InsertCommand = new SqlCommand(sql2, cnn);
                    //adapter.InsertCommand.ExecuteNonQuery();
                }
            }
            catch()
                {

            }
        }
    }
}
