using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class TestingBacklogItemState : IBacklogItemState
    {
        private readonly INotificationService _notificationService;
        private BacklogItem _backlogItem;
        private User? _leadDeveloper;
        private User? _scrumMaster;

        public TestingBacklogItemState(BacklogItem backlogItem, INotificationService notificationService, User? leadDeveloper, User? scrumMaster)
        {
            _notificationService = notificationService;
            _backlogItem = backlogItem;
            _leadDeveloper = leadDeveloper;
            _scrumMaster = scrumMaster;
        }

        public void UpdateUsers(User? newDeveloper, User? newScrumMaster) {
            _leadDeveloper = newDeveloper ?? _leadDeveloper;
            _scrumMaster = newScrumMaster ?? _scrumMaster; ;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog item in testing cannot be approved");
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item switched to tested");
            _backlogItem.currentState = _backlogItem.testedState;
            _notificationService.Send(_leadDeveloper != null ? [_leadDeveloper] : [], "Backlog item is completed, switch to complete");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog item denied, switching to do");
            _backlogItem.currentState = _backlogItem.todoState;
            _notificationService.Send(_scrumMaster != null ? [_scrumMaster] : [], "Backlog item is denied, switch to to do");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item in testing cannot be started");
        }
    }
}
