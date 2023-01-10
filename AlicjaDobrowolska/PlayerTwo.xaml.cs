using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static AlicjaDobrowolska.PlayerOne;

namespace AlicjaDobrowolska
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerTwo.xaml
    /// </summary>
    public partial class PlayerTwo : Window
    {
        public PlayerTwo()
        {
            InitializeComponent();
            CrBtn();
            counter.Content = 20;
            setCounter = 0;
            shootsHit = 0;
        }
        static int[] tab = new int[100];
        static int[] tab2 = new int[100];
        BattleshipLogic gra = new BattleshipLogic(tab, tab2);
        public int setCounter = 0;
        public int shootsHit = 0;
        void setButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                if (setCounter == 20) return;
                ((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]++;
                setCounter++;
                counter.Content = 20 - setCounter;
            }

            else if (((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]--;
                setCounter--;
                counter.Content = 20 - setCounter;
            }
        }
        void shootButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;

            }
            if (((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
            {
                ((BattleshipLogic)G1.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
                shootsHit++;
                if (gra.CheckWin(shootsHit))
                {
                    MessageBox.Show("WYGRYWA GRACZ DRUGI");
                };
            }
        }
        public void CrBtn()
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
                                    Path = new PropertyPath(Convert.ToString($"PersonIdOne[{x}]")),
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
                                    Path = new PropertyPath(Convert.ToString($"PersonIdTwo[{y}]")),
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
    }
}
