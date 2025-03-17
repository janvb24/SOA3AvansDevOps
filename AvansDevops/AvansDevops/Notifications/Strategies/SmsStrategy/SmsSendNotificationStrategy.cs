using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications.Strategies.SmsStrategy
{
    public class SmsSendNotificationStrategy : ISendNotificationStrategy
    {
        private SmsSendNotificationAdaptor _adaptor;

        public SmsSendNotificationStrategy()
        {
            _adaptor = new SmsSendNotificationAdaptor();
        }

        public void Send(User user, string message)
        {
            _adaptor.Send(user.phoneNumber, message);
        }
    }
}
