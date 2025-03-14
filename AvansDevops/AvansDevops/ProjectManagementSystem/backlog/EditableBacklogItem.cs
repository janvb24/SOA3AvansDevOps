namespace AvansDevops.ProjectManagementSystem.backlog {
    public class EditableBacklogItem : BacklogItem{
        public EditableBacklogItem(string title, int storyPoints, User? developer = null) {
            this.title = title;
            this.storyPoints = storyPoints;
            this.developer = developer;
        }

        public EditableBacklogItem(NonEditableBacklogItem nonEditableBacklogItem) {
            title = nonEditableBacklogItem.title;
            storyPoints = nonEditableBacklogItem.storyPoints;
            developer = nonEditableBacklogItem.developer;

        }
    }
}
