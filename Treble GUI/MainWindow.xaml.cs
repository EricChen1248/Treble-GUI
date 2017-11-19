using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Treble_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static string Account;
        public MainWindow()
        {
            InitializeComponent();
            Frame.Content = new Login(LoginSuccessful);
            Frame.Navigated += Frame_Navigated;
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Frame.NavigationService.RemoveBackEntry();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinimizeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginSuccessful(string account)
        {
            Frame.Content = null;
            Account = account;
            MessageBox.Show(Account);
        }

        
    }
}
