using System.Windows;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsEditPressed { get; set; }
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            IsEditPressed = true;
            this.Close();
        }
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            IsEditPressed = false;
            this.Close();
        }
    }
}
