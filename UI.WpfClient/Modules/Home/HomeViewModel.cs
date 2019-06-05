using Caliburn.Micro;
using System;
using System.Threading.Tasks;

namespace UI.WpfClient.Modules.Home
{
    public class HomeViewModel: Screen, IDashBoard
    {
        public string ProgressMessage { get; set; }

        public HomeViewModel()
        {
            DisplayName = "Dashboard page";
 
        }    
        
        public void DashboardClick()
        {
            ProgressMessage = $"progress message {DateTime.Now}";
        }
    }
}
