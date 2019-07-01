using UI.WpfClient.Models.Interfaces;

namespace UI.WpfClient.Models.Events
{
    public class VisibilityChangedEvent<T> where T: class
    {
        public bool IsVisible { get; set; }
    }
}
