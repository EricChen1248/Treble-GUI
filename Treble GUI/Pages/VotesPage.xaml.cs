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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for VotesPage.xaml
    /// </summary>
    public partial class VotesPage : Page
    {
        public VotesPage()
        {
            InitializeComponent();
        }


        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DestroyFloatingFrame();
        }
    }
}
