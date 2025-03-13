using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public interface ISendNotificationStrategy {
        void Send(User user, string message);
    }
}
