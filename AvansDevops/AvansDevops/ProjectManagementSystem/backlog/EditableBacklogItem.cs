namespace AvansDevops.ProjectManagementSystem.backlog {
    public class EditableBacklogItem : BacklogItem{
        public EditableBacklogItem(string title, int storyPoints, User? developer, User tester, User? scrumMaster, List<BacklogItem>? subTasks = null, BacklogItem? parent = null)
            : base(title, storyPoints, developer, tester, scrumMaster, subTasks, parent) { }

        public EditableBacklogItem(NonEditableBacklogItem backlogItem)
            : base(backlogItem.title,
                backlogItem.storyPoints,
                backlogItem.developer,
                backlogItem.tester,
                backlogItem.scrumMaster,
                backlogItem.subTasks,
                backlogItem.parent)
        {
        }

    }
}
