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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerGraphics_03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            WindowTask1 windowTask1 = new WindowTask1();
            windowTask1.Show();
            this.Close();
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            Task02 new_window = new Task02();
            new_window.Show();
        }
    }
}
