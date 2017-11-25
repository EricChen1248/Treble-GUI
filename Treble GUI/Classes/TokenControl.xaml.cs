
using System.Drawing;
using System.Windows.Media;
using Jdenticon;
using Treble_GUI.Pages;

namespace Treble_GUI.Classes
{
    /// <summary>
    /// Interaction logic for TokenControl.xaml
    /// </summary>
    public partial class TokenControl
    {
        public readonly string TokenID;
        public TokenControl(string tokenID, string address, string percentage)
        {
            InitializeComponent();
            MouseLeftButtonUp += TokenControl_MouseLeftButtonUp;
            TokenID = tokenID;
            DrawIcon();
            TokenName.Content = tokenID;
            TokenAddressLabel.Content = address;
            TokenPercentLbl.Content = percentage;
        }

        private void TokenControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.Instance.ChangeToToken(new TokenPage(TokenID));
        }

        private void DrawIcon()
        {
            var bitmap = new Bitmap(64, 64);
            var g = Graphics.FromImage(bitmap);
            Identicon.FromValue(TokenID, 64).Draw(g, new Rectangle(0, 0, 64, 64));

            TokenIcon.Fill = new ImageBrush(Helper.BitmapToImageSource(bitmap));

        }
        

    }
}
