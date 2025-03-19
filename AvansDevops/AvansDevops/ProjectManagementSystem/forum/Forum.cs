namespace AvansDevops.ProjectManagementSystem.forum
{
    public class Forum
    {
        public List<ForumTread> treads { get; set; }
        public Forum() {
            treads = new();
        }

        /// <summary>
        /// Adds new tread to forum
        /// </summary>
        /// <param name="tread">Tread to add</param>
        public void newTread(ForumTread tread) {
            treads.Add(tread);
        }
    }
}
