using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Treble_GUI.Pages;

namespace Treble_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Navigated += Frame_Navigated;
            InitTitleBar();

            Frame.Content = new Login(LoginSuccessful);
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

        private void LoginSuccessful(Dictionary<string,string> userData)
        {
            App.DespawnPage("loginPage", (Page) Frame.Content);
            Frame.Content = new Userpage(userData);
        }

        private void InitTitleBar()
        {
            var restoreIfMove = false;

            TitleBar.MouseDown += (s, e) =>
            {
                if (e.ClickCount == 2)
                {
                    MaximizeBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    return;
                }
                if (WindowState == WindowState.Maximized)
                {
                    restoreIfMove = true;
                }
                DragMove();
            };

            TitleBar.MouseUp += (s, e) => restoreIfMove = false;

            TitleBar.MouseMove += (s, e) =>
            {
                if (!restoreIfMove) return;

                restoreIfMove = false;
                var mouseX = e.GetPosition(this).X;
                var width = RestoreBounds.Width;
                var x = mouseX - width / 2;

                if (x < 0)
                {
                    x = 0;
                }
                else if (x + width > Width)
                {
                    x = Width - width;
                }

                WindowState = WindowState.Normal;
                Left = x;
                Top = 0;
                DragMove();
            };
        }
    }
}
