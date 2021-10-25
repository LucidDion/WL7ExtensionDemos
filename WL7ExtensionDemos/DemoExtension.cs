using System.Collections.Generic;
using System.Windows.Controls;
using WealthLab.WPF;
using System.Windows;

namespace WL7ExtensionDemos
{
    //Our WL7 ExtensionBase class, which provides new menu items to WL7's Extension menu, and can inject content into the Help system and QuickRef
    public class DemoExtension : WL7ExtensionBase
    {
        //Initialize
        public override List<MenuItem> Initialize()
        {
            //create and return a menu item that will open our ChildWindow
            List<MenuItem> mi = new List<MenuItem>();
            MenuItem mni = CreateExtensionMenuItem("Demo Extension", Properties.Resources.Demo, mniClick);
            mi.Add(mni);
            return mi;
        }

        //private members

        //extension menu item was clicked, create our ChildWindow and make it appear in WL7
        private void mniClick(object sender, RoutedEventArgs e)
        {
            DemoChildWindow dcw = new DemoChildWindow();
            MyClientHost.ShowExtensionChildWindow(dcw, "Demo ChildWindow", Properties.Resources.Demo);
        }
    }
}