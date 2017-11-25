using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Jdenticon;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for TokenPage.xaml
    /// </summary>
    public partial class TokenPage
    {
        private readonly string tokenID;
        public TokenPage(string tokenID)
        {
            InitializeComponent();
            this.tokenID = tokenID;
            TokenLabel.Content = tokenID;
            DrawIcon();
        }


        private void DrawIcon()
        {
            var bitmap = new Bitmap(64, 64);
            var g = Graphics.FromImage(bitmap);
            Identicon.FromValue(tokenID, 64).Draw(g, new Rectangle(0, 0, 64, 64));

            TokenIcon.Fill = new ImageBrush(Helper.BitmapToImageSource(bitmap));
        }


        private void BackLabel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangeToToken(App.GetNewPage("userPage"));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            App.DespawnPage("TokenPage", this);
            MainWindow.Instance.NewFloatingFrame(new BuyToken(tokenID));
        }


    }
}
