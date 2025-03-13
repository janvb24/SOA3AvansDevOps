using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public interface INotificationService {
        /// <summary>
        /// Method <c>SetStraegy</c> sets the strategy for sending notifications.
        /// </summary>
        /// <param name="strategy">The strategy to use for sending notifications</param>
        void SetStrategy(ISendNotificationStrategy strategy);

        /// <summary>
        /// Method <c>Send</c> send message to all users in the list.
        /// </summary>
        /// <param name="users">The list of users That should revieve the message</param>
        /// <param name="message">The message to send to the user</param>
        void Send(List<User> users, string message);
    }
}
