
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
            TokenPanel.Children.Add(new TokenControl("京華大樓 11F", "台北市大安區建國南路一段 291 巷 25 號", "2%"));
            TokenPanel.Children.Add(new TokenControl("千里華夏 1F", "台北市萬華區大理街 170 巷 8 號", "10%"));

            // Token Count
            // Token Percentage

        }


    }
}
