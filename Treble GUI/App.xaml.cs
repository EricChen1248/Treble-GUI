using System.Collections.Generic;
using System.Windows.Controls;
using Treble_GUI.Classes.Exceptions;

namespace Treble_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static readonly Dictionary<string, Page> pagePool = new Dictionary<string, Page>();

        public static Page GetNewPage(string pageName)
        {
            if (!pagePool.ContainsKey(pageName))
            {
                throw new NoPageException();
            }

            var page = pagePool[pageName];
            pagePool.Remove(pageName);
            return page;
        }

        public static void DespawnPage(string pageName, Page page)
        {
            if (pagePool.ContainsKey(pageName))
            {
                throw new DuplicatePageException();;
            }

            pagePool[pageName] = page;
        }


    }
}
