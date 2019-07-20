using Caliburn.Micro;
using System;

namespace UI.WpfClient.Models.Events
{
    public class ChangeScreenEvent
    {
        public IScreen ViewModel { get; set; }
        public bool ClosePrevious { get; set; }
    }
}
