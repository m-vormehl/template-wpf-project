namespace Framework.WpfClient.Models.Events
{
    public class LoginAttemptEvent
    {
        public string UserName { get; set; }
        public bool IsLoginSuccessful { get; set; }
    }
}
