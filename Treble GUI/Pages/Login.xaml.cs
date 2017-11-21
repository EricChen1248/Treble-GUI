﻿using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        private readonly Action<string> loginSuccessful;
        public Login(Action<string> login)
        {
            InitializeComponent();
            loginSuccessful = login;
        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            // TODO: Check DataBase
            loginSuccessful(UserBox.Text.ToLower());
        }

        private void PasswordBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
