using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public class NotificationService : INotificationService { 
        private ISendNotificationStrategy _strategy;

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
