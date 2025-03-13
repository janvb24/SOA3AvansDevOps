namespace AvansDevops.Notifications.Strategies.EmailStrategy
{
    public class EmailSendNotificationAdaptor
    {
        private readonly EmailLibrary _emailLibrary;

        public EmailSendNotificationAdaptor()
        {
            _emailLibrary = new EmailLibrary();
        }

        /// <summary>
        /// Send a message to a specific email address.
        /// </summary>
        /// <param name="emailAddress">Email address that the messsage should be send to</param>
        /// <param name="message">Message that should be send to the email address<param>
        public void Send(string emailAddress, string message)
        {
            _emailLibrary.SendEmail(emailAddress, message);
        }
    }
}
