namespace AvansDevops.ProjectManagementSystem.backlog {
    public class NonEditableBacklogItem : BacklogItem{
        public NonEditableBacklogItem(string title, int storyPoints, User? developer, User tester, User scrumMaster, List<BacklogItem>? subTasks = null, BacklogItem? parent = null)
            : base(title, storyPoints, developer, tester, scrumMaster, subTasks, parent) { }

        public NonEditableBacklogItem(EditableBacklogItem backlogItem)
            : base(backlogItem.title,
                backlogItem.storyPoints,
                backlogItem.developer,
                backlogItem.tester,
                backlogItem.scrumMaster,
                backlogItem.subTasks,
                backlogItem.parent)
        {
        }

        // Override setters to prevent modification
        public override string title {
            get => base.title;
            set => throw new ArgumentException("Title cannot be altered");
        }

        public override int storyPoints {
            get => base.storyPoints;
            set => throw new ArgumentException("Story points cannot be altered");
        }

        public override List<BacklogItem> subTasks {
            get => base.subTasks;
            set => throw new ArgumentException("Subtasks cannot be altered");
        }

        public override BacklogItem? parent {
            get => base.parent;
            set => throw new ArgumentException("Parent cannot be altered");
        }
    }
}
