
using System.Collections.Generic;
using Treble_GUI.Classes;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Userpage.xaml
    /// </summary>
    public partial class Userpage
    {
        private Dictionary<string, string> userData;
        public Userpage(Dictionary<string, string> userData)
        {
            InitializeComponent();

            this.userData = userData;
            UserLabel.Content = userData["AccountName"];
            MoneyLabel.Content = $"{int.Parse(userData["Money"]):C0}";
            TokenPanel.Children.Add(new TokenControl("National Taiwan University Library"));
            TokenPanel.Children.Add(new TokenControl("National Taiwan University MB2"));

            // Token Count
            // Token Percentage

        }
    }
}
