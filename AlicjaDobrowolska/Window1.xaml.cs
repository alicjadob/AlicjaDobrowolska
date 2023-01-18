﻿using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsEditPressed { get; set; }
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Edytuj(object sender, RoutedEventArgs e)
        {
            IsEditPressed = true;
            this.Close();
        }
        private void Button_Anuluj(object sender, RoutedEventArgs e)
        {
            IsEditPressed = false;
            this.Close();
        }
    }
}
