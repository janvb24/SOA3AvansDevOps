namespace AvansDevops.Notifications.Strategies.EmailStrategy
{
    public class EmailLibrary
    {
        public void SendEmail(string emailAddress, string message)
        {
            Console.WriteLine($"Sending email to {emailAddress}: {message}");
        }
    }
}
