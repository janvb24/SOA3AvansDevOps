namespace AvansDevops.Notifications.Strategies.SmsStrategy
{
    public class SmsSendNotificationAdaptor
    {
        private SmsLibrary _smsLibrary;

        public SmsSendNotificationAdaptor()
        {
            _smsLibrary = new SmsLibrary();
        }

        /// <summary>
        /// Send a message to a specific phone number.
        /// </summary>
        /// <param name="phoneNumber">The number that should recieve the message.</param>
        /// <param name="message">The message that should be send.</param>
        public void Send(string phoneNumber, string message)
        {
            _smsLibrary.SendSms(phoneNumber, message);
        }
    }
}
