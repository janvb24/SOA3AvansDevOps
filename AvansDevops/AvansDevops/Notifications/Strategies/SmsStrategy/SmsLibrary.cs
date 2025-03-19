namespace AvansDevops.Notifications.Strategies.SmsStrategy
{
    public class SmsLibrary
    {
        /// <summary>
        /// Send a message to a specific phone number.
        /// </summary>
        /// <param name="phoneNumber">The number that should recieve the message.</param>
        /// <param name="message">The message that should be send.</param>
        public void SendSms(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
        }
    }
}
