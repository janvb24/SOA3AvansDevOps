using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog.state;

namespace AvansDevops.ProjectManagementSystem.backlog
{
    public abstract class BacklogItem {
        //NOTE: virtual properties are used to allow for overriding in NonEditableBacklogItem so they cannot be altered in NonEditableBacklogItem
        private string _title = string.Empty;
        private int _storyPoints;
        private BacklogItem? _parent;
        private List<BacklogItem>? _subTasks = null;
        private User? _developer;
        public TodoBacklogItemState todoState;
        public DoingBacklogItemState doingState;
        public ReadyForTestingBacklogItemState readyForTestingState;
        public TestingBacklogItemState testingState;
        public TestedBacklogItemState testedState;
        public DoneBacklogItemState doneState;
        public IBacklogItemState currentState { get; set; }


        public virtual string title {
            get => _title;
            set => _title = value;
        }

        public virtual int storyPoints {
            get => _storyPoints;
            set => _storyPoints = value;
        }

        public virtual User? developer {
            get => _developer;
            set => _developer = value;
        }

        public virtual List<BacklogItem>? subTasks {
            get => _subTasks;
            set {
                if (_parent == null) {
                    _subTasks = value;
                } else {
                    throw new ArgumentException("Subtask cannot contain subtasks");
                }   
            }
        }
        public virtual BacklogItem? parent {
            get => _parent;
            set {
                if (_subTasks == null) {
                    _parent = value;
                } else {
                    throw new ArgumentException("Backlog item cannot become subtask");
                }
            }
        }

        protected BacklogItem(string title, int storyPoints, User? developer = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null) {
            _title = title;               
            _storyPoints = storyPoints;
            _developer = developer;
            if (parent != null) {
                _subTasks = null;
                _parent = parent;
            } else {
                _subTasks = subTasks ?? [];
                _parent = null;
            }

            //States
            //For now the users are hardcoded, but in the future this could be a parameter
            User leadDeveloper = new User("Lead Developer", "email@email.nl", "063938385");
            List<User> testers = [new User("Tester", "", ""), new User("Tester", "", "")];
            User scrumMaster = new User("ScrumMaster", "", "");
            INotificationService notificationService = new NotificationService();
            todoState = new TodoBacklogItemState(this);
            doingState = new DoingBacklogItemState(this, notificationService, testers);
            readyForTestingState = new ReadyForTestingBacklogItemState(this);
            testingState = new TestingBacklogItemState(this, notificationService, leadDeveloper, scrumMaster);
            testedState = new TestedBacklogItemState(this);
            doneState = new DoneBacklogItemState(this);
            currentState = todoState;
        }
    }
}
