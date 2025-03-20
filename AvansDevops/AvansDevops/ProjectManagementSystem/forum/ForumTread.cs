using AvansDevops.Notifications;

namespace AvansDevops.ProjectManagementSystem.forum
{
    public class ForumTread
    {
        private INotificationService _notificationService;
        public List<ForumTreadItem> items { get; set; }
        private User user;

        public ForumTread(INotificationService notificationService, User user) {
            _notificationService = notificationService;
            items = new();
            this.user = user;
        }
    }
}
