
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Jdenticon;

namespace Treble_GUI.Pages
{
    /// <summary>
    /// Interaction logic for TokenControl.xaml
    /// </summary>
    public partial class TokenControl
    {
        private readonly string tokenID;
        public TokenControl(string tokenID)
        {
            InitializeComponent();
            MouseLeftButtonUp += TokenControl_MouseLeftButtonUp;
            this.tokenID = tokenID;
            DrawIcon();
            TokenName.Content = tokenID;
        }

        private void TokenControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Handles Token Click
            MessageBox.Show("Token is clicked");
        }

        private void DrawIcon()
        {
            var bitmap = new Bitmap(64, 64);
            var g = Graphics.FromImage(bitmap);
            Identicon.FromValue(tokenID, 64).Draw(g, new Rectangle(0, 0, 64, 64));

            TokenIcon.Fill = new ImageBrush(Helper.BitmapToImageSource(bitmap));

        }
        

    }
}
