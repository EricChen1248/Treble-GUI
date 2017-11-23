using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Treble_GUI.Classes;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        private readonly Action<Dictionary<string,string>> loginSuccessful;
        public Login(Action<Dictionary<string, string>> login)
        {
            InitializeComponent();
            loginSuccessful = login;

#if DEBUG
            UserBox.Text = "ericchen1248";
            PasswordBox.Password = "password";
#endif

        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
           TryLogin();
        }

        private void PasswordBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TryLogin();
            }
        }

        private void FailedLogin()
        { 
            MessageBox.Show(@"Account or Password Error");
        }

        private void TryLogin()
        {
            // Hashing Password with SHA1
            var hashedPassword = new ASCIIEncoding().GetString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(PasswordBox.Password)));


            var data = Server.GetDatabase("Accounts");
            var users = data["Username"];

            var userName = UserBox.Text.ToLower();
            if (users.Contains(userName) == false)
            {
                FailedLogin();
                MessageBox.Show(users[0]);
                return;
            }


            var index = userName.IndexOf(userName, StringComparison.Ordinal);
            if (data["Password"][index] != hashedPassword)
            {
                FailedLogin();
                return;
            }


            var userData = new Dictionary<string, string>();
            foreach (var dataKey in data.Keys)
            {
                userData[dataKey] = data[dataKey][index];
            }

            loginSuccessful(userData);

        }
    }
}
