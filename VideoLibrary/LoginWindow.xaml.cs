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

namespace VideoLibrary
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(database.test());
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            if (database.login(username, password))
            {
                Window libraryWindow = new LibraryWindow();
                Application.Current.MainWindow = libraryWindow;
                this.Close();
                libraryWindow.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }
    }
}
