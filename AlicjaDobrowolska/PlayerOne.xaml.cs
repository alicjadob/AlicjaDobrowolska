using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerOne.xaml
    /// </summary>
    public partial class PlayerOne : Window
    {
        static int[] tab = new int[100];
        static int[] tab2 = new int[100];
        BattleshipLogic gra = new BattleshipLogic(tab, tab2);
        PlayerTwo okno = new PlayerTwo();
        public PlayerOne()
        {
            InitializeComponent();
            CrBtn();
            G1.DataContext = gra;
            okno.DataContext = gra;
            okno.Show();
            counter.Content = 20;
        }

        int setCounter = 0;
        int shootsHit = 0;
        void setButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                if (setCounter == 20) return;
                ((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]++;
                setCounter++;
                counter.Content = 20 - setCounter;
            }
            else if (((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]--;
                setCounter--;
                counter.Content = 20 - setCounter;
            }
        }

        void shootButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;

            }
            if (((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
                shootsHit++;
                if (gra.CheckWin(shootsHit))
                {
                    MessageBox.Show("WYGRYWA GRACZ PIERWSZY");
                };
            }
        }
        private void CrBtn()
        {
            int x = 0;
            int y = 0;
            for (int k = 0; k < 2; k++)
            {
                switch (k)
                {
                    //strzelanie
                    case 0:
                        for (int i = 1; i < 11; i++)
                        {
                            for (int j = 1; j < 11; j++)
                            {
                                Button button = new Button();
                                button.Tag = $"{x}";
                                Grid.SetColumn(button, i);
                                Grid.SetRow(button, j);
                                strzal.Children.Add(button);
                                button.Click += new RoutedEventHandler(shootButton_Click);
                                YesNoToBooleanConverter2 yesNoToBooleanConverter2 = new YesNoToBooleanConverter2();
                                Binding bind = new Binding
                                {
                                    Path = new PropertyPath(Convert.ToString($"PersonIdTwo[{x}]")),
                                    Mode = BindingMode.TwoWay,
                                    Converter = yesNoToBooleanConverter2,
                                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                                };
                                button.SetBinding(Button.BackgroundProperty, bind);
                                x++;

                            }
                        }
                        break;
                    //stawianie
                    case 1:
                        for (int i = 1; i < 11; i++)
                        {
                            for (int j = 1; j < 11; j++)
                            {
                                Button button = new Button();
                                button.Tag = $"{y}";
                                Grid.SetColumn(button, i);
                                Grid.SetRow(button, j);
                                ustaw.Children.Add(button);
                                button.Click += new RoutedEventHandler(setButton_Click);
                                YesNoToBooleanConverter yesNoToBooleanConverter = new YesNoToBooleanConverter();
                                Binding bind = new Binding
                                {
                                    Path = new PropertyPath(Convert.ToString($"PersonIdOne[{y}]")),
                                    Mode = BindingMode.TwoWay,
                                    Converter = yesNoToBooleanConverter,
                                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                                };
                                button.SetBinding(Button.BackgroundProperty, bind);
                                y++;

                            }
                        }
                        break;
                }
            }


        }
        public class YesNoToBooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                switch (value)
                {
                    case 3:
                        return new SolidColorBrush(Colors.Red);
                    case 2:
                        return new SolidColorBrush(Colors.Yellow);
                    case 1:
                        return new SolidColorBrush(Colors.Black);
                    case 0:
                        return new SolidColorBrush(Colors.Transparent);
                }
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is Colors)
                {
                    //if ((Colors)value == Colors.Red)
                    //    return 4;
                    //else
                    //    return 0;
                }
                return 0;
            }
        }

        public class YesNoToBooleanConverter2 : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                switch (value)
                {
                    case 3:
                        return new SolidColorBrush(Colors.Red);
                    case 2:
                        return new SolidColorBrush(Colors.Yellow);
                    case 1:
                        return new SolidColorBrush(Colors.Transparent);
                    case 0:
                        return new SolidColorBrush(Colors.Transparent);
                }
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is Colors)
                {
                    //if ((Colors)value == Colors.Red)
                    //    return 4;
                    //else
                    //    return 0;
                }
                return 0;
            }
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            int[] tab1 = new int[100];
            int[] tab3 = new int[100];
            BattleshipLogic gra = new BattleshipLogic(tab1, tab3);
            G1.DataContext = gra;
            okno.DataContext = gra;
            counter.Content = 20;
            setCounter = 0;
            shootsHit = 0;
            okno.setCounter = 0;
            okno.shootsHit = 0;
            okno.counter.Content = 20;
        }
    }
}
