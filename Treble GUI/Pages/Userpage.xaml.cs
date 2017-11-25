
using System.Collections.Generic;
using Treble_GUI.Classes;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for Userpage.xaml
    /// </summary>
    public partial class Userpage
    {
        public List<TokenControl> tokens = new List<TokenControl>();
        private static Dictionary<string, string> UserData;
        public static string UserName => UserData["AccountName"];
        public static int Money
        {
            get => int.Parse(UserData["Money"]);
            set => UserData["Money"] = $"{value}";
        }

        public Userpage(Dictionary<string, string> userData)
        {
            InitializeComponent();

            UserData = userData;

            UserLabel.Content = UserName;
            MoneyLabel.Content = $"{Money:C0}";
            
            tokens.Add(new TokenControl("京華大樓 11F", "台北市大安區建國南路一段 291 巷 25 號", "2%"));
            tokens.Add(new TokenControl("千里華夏 1F", "台北市萬華區大理街 170 巷 8 號", "10%"));

            foreach (var tokenControl in tokens)
            {
                TokenPanel.Children.Add(tokenControl);
            }

            // Token Count
            // Token Percentage

        }

        public void SaveUserData()
        {
            // TODO Save UserData
        }

        public void UpdateData()
        {
            UserLabel.Content = UserName;
            MoneyLabel.Content = $"{Money:C0}";
        }



    }
}
