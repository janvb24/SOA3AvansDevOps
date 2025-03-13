namespace AvansDevops.Notifications.Strategies.SmsStrategy
{
    public class SmsLibrary
    {
        public void SendSms(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
        }
    }
}
