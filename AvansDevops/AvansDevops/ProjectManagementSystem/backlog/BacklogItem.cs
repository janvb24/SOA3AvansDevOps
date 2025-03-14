namespace AvansDevops.ProjectManagementSystem.backlog {
    public abstract class BacklogItem {
        //NOTE: virtual properties are used to allow for overriding in NonEditableBacklogItem so they cannot be altered in NonEditableBacklogItem
        private string _title = string.Empty;
        private int _storyPoints;
        private List<BacklogItem> _subTasks = [];
        private BacklogItem? _parent;
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

        public virtual List<BacklogItem> subTasks {
            get => _subTasks;
            set => _subTasks = value ?? [];
        }

        public virtual BacklogItem? parent {
            get => _parent;
            set => _parent = value;
        }

        protected BacklogItem(string title, int storyPoints, User? developer = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null) {
            _title = title;               
            _storyPoints = storyPoints;
            _developer = developer;
            _subTasks = subTasks ?? [];
            _parent = parent;
        }
    }
}
