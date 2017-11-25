using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for BuyToken.xaml
    /// </summary>
    public partial class BuyToken
    {
        
        private readonly List<int> price = new List<int>();
        private readonly string tokenID;
        public BuyToken(string tokenID)
        {
            InitializeComponent();
            this.tokenID = tokenID;
            MoneyLabel.Content = $"{Userpage.Money:C0}";

            // TODO hardcoded count and price
            for (int i = 0; i < 3; i++)
            {
                price.Add(50200);
            }
            for (int i = 0; i < 2; i++)
            {
                price.Add(55000);
            }
            for (int i = 0; i < 5; i++)
            {
                price.Add(60000);
            }
        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            var totalPrice = 0;
            for (var i = 0; i < numValue; i++)
            {
                totalPrice += price[i];
            }

            if (Userpage.Money > totalPrice)
            {
                Userpage.Money -= totalPrice;
            }

            if (App.GetNewPage("userPage") is Userpage page)
            {
                foreach (var tokenControl in page.tokens)
                {
                    if (tokenControl.TokenID == tokenID)
                    {
                        tokenControl.TokenPercentLbl.Content = $"{(10 + numValue) * 100 / 500d:N0}%";
                    }
                }

                page.UpdateData();

                App.DespawnPage("userPage", page);
            }

            if (App.GetNewPage("TokenPage") is TokenPage tokenPage)
            {
                tokenPage.TokenCount.Content = $"{10 + numValue}/100";
            }

            MainWindow.Instance.DestroyFloatingFrame();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DestroyFloatingFrame();
        }

        private int numValue;

        public int NumValue
        {
            get => numValue;
            set
            {
                if (value >= price.Count || value < 0)
                {
                    return;
                }
                numValue = value;
                TxtNum.Text = value.ToString();

                var totalPrice = 0;
                for (var i = 0; i < numValue; i++)
                {
                    totalPrice += price[i];
                }

                TotalPrice.Content = $"{totalPrice:C0}";
            }
        }
        
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxtNum == null)
            {
                return;
            }

            if (!int.TryParse(TxtNum.Text, out numValue))
                TxtNum.Text = numValue.ToString();
        }
    }
}
