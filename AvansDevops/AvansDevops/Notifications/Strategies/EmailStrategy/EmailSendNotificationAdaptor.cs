namespace AvansDevops.Notifications.Strategies.EmailStrategy
{
    public class EmailSendNotificationAdaptor
    {
        private readonly EmailLibrary _emailLibrary;

        public EmailSendNotificationAdaptor()
        {
            _emailLibrary = new EmailLibrary();
        }

        public void Send(string emailAddress, string message)
        {
            _emailLibrary.SendEmail(emailAddress, message);
        }
    }
}
