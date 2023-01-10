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
using System.Windows.Shapes;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Interaction logic for kolkokrzyzyk.xaml
    /// </summary>
    public partial class kolkokrzyzyk : Window
    {
        public GameLogic _GameLogic = new GameLogic();
        public kolkokrzyzyk()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = _GameLogic.CurrentPlayer;
            var coordinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(coordinates[0]);
            var yValue = int.Parse(coordinates[1]);
            var buttonPosition = new Position() { x = xValue, y = yValue };
            _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);
            if(_GameLogic.PlayerWin())
            {
                WinScreen.Text = $"{_GameLogic.CurrentPlayer} WINS";
                WinScreen.Visibility = Visibility.Visible;
            }
            _GameLogic.SetNextPlayer();
        }
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach( var control in ticTacGrid.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
            }
            _GameLogic = new GameLogic();
            WinScreen.Visibility = Visibility.Collapsed;
        }
    }
}
