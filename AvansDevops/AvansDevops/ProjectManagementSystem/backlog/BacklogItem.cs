namespace AvansDevops.ProjectManagementSystem.backlog {
    public abstract class BacklogItem {
        //NOTE: virtual properties are used to allow for overriding in NonEditableBacklogItem so they cannot be altered in NonEditableBacklogItem
        private string _title = string.Empty;
        private int _storyPoints;
        private BacklogItem? _parent;
        private List<BacklogItem>? _subTasks = null;
        private User? _developer;
        //TODO: status/State

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
        }
    }
}
