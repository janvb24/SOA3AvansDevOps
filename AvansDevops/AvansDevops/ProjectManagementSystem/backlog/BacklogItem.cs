namespace AvansDevops.ProjectManagementSystem.backlog {
    public abstract class BacklogItem {
        public string title { get; set; }
        public int storyPoints { get; set; }
        public User? developer { get; set; }
        
        //TODO: Status (of ook wel die state)
    }
}
