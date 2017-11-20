using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Treble_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private Dictionary<string, Page> pagePool = new Dictionary<string, Page>();

        public Page GetNewPage(string pageName)
        {
            // TODO: Implement Page Spawning
        }

        public void DespawnPage(string pageName, Page page)
        {
            // TODO: Implement Page Despawning
        }


    }
}
