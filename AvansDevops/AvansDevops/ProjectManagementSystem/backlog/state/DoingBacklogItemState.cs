using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class DoingBacklogItemState : IBacklogItemState
    {
        private readonly INotificationService _notificationService;
        private BacklogItem _backlogItem;
        private User _tester;

        public DoingBacklogItemState(BacklogItem backlogItem, INotificationService notificationService, User tester)
        {
            _backlogItem = backlogItem;
            _notificationService = notificationService;
            _tester = tester;
        }


        public void Approve()
        {
            Console.WriteLine("Backlog item in doing cannot be approved");
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item switched to ready for testing");
            _backlogItem.currentState = _backlogItem.readyForTestingState;
            _notificationService.Send([_tester], "Backlog item is ready for testing");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog item in doing cannot be denied");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item in doing cannot be started");
        }
    }
}
