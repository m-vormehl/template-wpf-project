using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace UI.WpfClient.Modules.Home{
    public partial class HomeView : UserControl{
        public HomeView(){
            InitializeComponent();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            HamburgerMenuControl.Content = e.InvokedItem;
        }
    }
}
