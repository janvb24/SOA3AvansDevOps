namespace AvansDevops.ProjectManagementSystem.backlog {
    public class EditableBacklogItem : BacklogItem{
        public EditableBacklogItem(string title, int storyPoints, User? developer, User tester, User scrumMaster, List<BacklogItem>? subTasks = null, BacklogItem? parent = null)
            : base(title, storyPoints, developer, tester, scrumMaster, subTasks, parent) { }

        public EditableBacklogItem(NonEditableBacklogItem nonEditableBacklogItem, User tester, User scrumMaster)
            : base(nonEditableBacklogItem.title, nonEditableBacklogItem.storyPoints, nonEditableBacklogItem.developer, tester, scrumMaster, nonEditableBacklogItem.subTasks, nonEditableBacklogItem.parent) { }

    }
}
