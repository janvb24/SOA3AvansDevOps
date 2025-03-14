namespace AvansDevops.ProjectManagementSystem.backlog {
    public class NonEditableBacklogItem : BacklogItem{
        public NonEditableBacklogItem(string title, int storyPoints, User? developer = null) {
            this.title = title;
            this.storyPoints = storyPoints;
            this.developer = developer;
        }

        public NonEditableBacklogItem(EditableBacklogItem editableBacklogItem) {
            title = editableBacklogItem.title;
            storyPoints = editableBacklogItem.storyPoints;
            developer = editableBacklogItem.developer;
        }
    }
}
