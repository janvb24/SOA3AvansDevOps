namespace AvansDevops.ProjectManagementSystem.backlog {
    public class EditableBacklogItem : BacklogItem{
        public EditableBacklogItem(string title, int storyPoints, User? developer = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null)
            : base(title, storyPoints, developer, subTasks, parent) { }

        public EditableBacklogItem(NonEditableBacklogItem nonEditableBacklogItem)
            : base(nonEditableBacklogItem.title, nonEditableBacklogItem.storyPoints, nonEditableBacklogItem.developer, nonEditableBacklogItem.subTasks, nonEditableBacklogItem.parent) { }

    }
}
