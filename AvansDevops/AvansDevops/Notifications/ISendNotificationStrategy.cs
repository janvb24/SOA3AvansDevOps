using AvansDevops.ProjectManagementSystem;

namespace AvansDevops.Notifications {
    public interface ISendNotificationStrategy {
        /// <summary>
        /// Method <c>Send</c> sends a message to a user with a speicif strategy.
        /// </summary>
        /// <param name="user">The user to send the message to.</param>
        /// <param name="message">The message to send to the user</param>
        void Send(User user, string message);
    }
}
