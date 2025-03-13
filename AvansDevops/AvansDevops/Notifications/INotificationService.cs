using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public interface INotificationService {
        void SetStrategy(ISendNotificationStrategy strategy);
        void Send(List<User> users, string message);
    }
}
