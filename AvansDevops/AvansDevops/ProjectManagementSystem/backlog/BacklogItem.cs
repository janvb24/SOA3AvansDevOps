using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog.state;

namespace AvansDevops.ProjectManagementSystem.backlog
{
    public abstract class BacklogItem {
        //NOTE: virtual properties are used to allow for overriding in NonEditableBacklogItem so they cannot be altered in NonEditableBacklogItem
        protected string _title = string.Empty;
        protected int _storyPoints;
        protected BacklogItem? _parent;
        protected List<BacklogItem>? _subTasks = null;
        private User? _developer;
        private User? _tester;
        private User? _scrumMaster;
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

        public virtual User? developer {
            get => _developer;
            set {
                this.testingState?.UpdateUsers(value, null);
                _developer = value;
            }
        }

        public virtual User? tester {
            get => _tester;
            set {
                this.doingState?.UpdateTester(value);
                this.testedState?.UpdateTester(value);
                _tester = value;
            }
        }

        public virtual User? scrumMaster {
            get => _scrumMaster;
            set {
                this.testingState?.UpdateUsers(null, value);
                _scrumMaster = value;
            }
        }

        protected BacklogItem(string title, int storyPoints, User? developer, User? tester = null, User? scrumMaster = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null) {
            _title = title;               
            _storyPoints = storyPoints;
            this.developer = developer;
            if (parent != null) {
                _subTasks = null;
                _parent = parent;
            } else {
                _subTasks = subTasks ?? [];
                _parent = null;
            }

            this.tester = tester;
            this.scrumMaster = scrumMaster;

            //States
            INotificationService notificationService = new NotificationService();
            todoState = new TodoBacklogItemState(this);
            doingState = new DoingBacklogItemState(this, notificationService, tester);
            readyForTestingState = new ReadyForTestingBacklogItemState(this);
            testingState = new TestingBacklogItemState(this, notificationService, this.developer, scrumMaster);
            testedState = new TestedBacklogItemState(this, notificationService, tester);
            doneState = new DoneBacklogItemState(this);
            currentState = todoState;
        }
        
        /// <summary>
        /// Makes all subtasks persistent so they can not be changed again.
        /// This also disables the ability to change their state.
        /// </summary>
        public void PersistSubtasks()
        {
            if (_subTasks == null) return;
            
            List<BacklogItem> persistentSubTasks = [];
            _subTasks.ForEach(subTask =>
            {
                persistentSubTasks.Add(new NonEditableBacklogItem(subTask as EditableBacklogItem));
            });
            _subTasks = persistentSubTasks;
        }

        /// <summary>
        /// Runs start method from current state
        /// </summary>
        public void Start() {
            currentState.Start();
        }

        /// <summary>
        /// Runs complete method from current state
        /// </summary>
        public void Complete() {
            currentState.Complete();
        }

        /// <summary>
        /// Runs approve method from current state
        /// </summary>
        public void Deny() {
            currentState.Deny();
        }

        /// <summary>
        /// Runs approve method from current state
        /// </summary>
        public void Approve() {
            currentState.Approve();
        }
    }
}
