using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UI.WpfClient.UserControls;

namespace UI.WpfClient.Modules.Home
{
    public class HomeViewModel: Screen, IDashBoard
    {
        public IObservableCollection<object> DisplayedTasksList { get; set; }
        public object RightSideContent { get; set; }

        public HomeViewModel()
        {
            DisplayName = "Dashboard page";
            //DisplayedTasksList = new IObservableCollection<string>();
            RightSideContent = new DashboardChart();
        }    
        
        public void DashboardClick()
        {

        }
    }
}
