using AvansDevops.Notifications.Strategies.EmailStrategy;
using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public class NotificationService : INotificationService { 
        private ISendNotificationStrategy _strategy = new EmailSendNotificationStrategy();

        public void SetStrategy(ISendNotificationStrategy strategy) {
            _strategy = strategy;
        }

        public void Send(List<User> users, string message) {
            foreach (var user in users) {
                _strategy.Send(user, message);
            }
        }
    }
}
