using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications.Strategies.EmailStrategy
{
    public class EmailSendNotificationStrategy : ISendNotificationStrategy
    {
        private readonly EmailSendNotificationAdaptor _adaptor;

        public EmailSendNotificationStrategy()
        {
            _adaptor = new EmailSendNotificationAdaptor();
        }

        public void Send(User user, string message)
        {
            _adaptor.Send(user.email, message);
        }
    }
}
