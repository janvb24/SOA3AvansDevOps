namespace AvansDevops.Notifications.Strategies.EmailStrategy
{
    public class EmailLibrary
    {
        /// <summary>
        /// Send a message to a specific email address.
        /// </summary>
        /// <param name="emailAddress">Email address that the messsage should be send to</param>
        /// <param name="message">Message that should be send to the email address<param>
        public void SendEmail(string emailAddress, string message)
        {
            Console.WriteLine($"Sending email to {emailAddress}: {message}");
        }
    }
}
