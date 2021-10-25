using System.Collections.Generic;
using System.Windows.Controls;
using WealthLab.WPF;

namespace WL7ExtensionDemos
{
    //This child window will appear when the "Demo" menu item is selected under the WL7 Extensions menu
    public partial class DemoChildWindow : ChildWindow
    {
        //constructor
        public DemoChildWindow()
        {
            InitializeComponent();
        }

        //a "Token" is used for internal tracking of the Child Window, specifically when saving and restoring Workspaces
        public override string Token => "Demo";
    }
}