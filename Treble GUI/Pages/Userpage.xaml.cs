
using Treble_GUI.Classes;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Userpage.xaml
    /// </summary>
    public partial class Userpage
    {
        private readonly string Account;
        public Userpage(string account)
        {
            InitializeComponent();
            Account = account;
            UserLabel.Content = Account;
            TokenPanel.Children.Add(new TokenControl("National Taiwan University Library"));
            TokenPanel.Children.Add(new TokenControl("National Taiwan University MB2"));

            // Token Count
            // Token Percentage

        }
    }
}
