using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.ProjectManagementSystem.forum;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevops.ProjectManagementSystem
{
    public class Project {
        private readonly IGitVersionControl _versionControl;
        public Backlog projectBacklog { get; set; } = new Backlog();  
        public List<User> testers { get; set; } = new List<User>();
        public User leadDeveloper { get; set; }
        public List<User> developers { get; set; }
        public Forum forum { get; set; } = new Forum();
        public Sprint currentSprint { get; private set; }

        public Project(IGitVersionControl versionControl, User leadDeveloper, List<User>? developers = null) {
            _versionControl = versionControl;
            this.leadDeveloper = leadDeveloper;
            this.developers = developers ?? [];
        }
        
        public void NewSprint(User scrumMaster, IPipeline pipeline, string name, SprintType type)
        {
            currentSprint = type switch
            {
                SprintType.RELEASE_SPRINT => 
                    new ReleaseSprint(this, scrumMaster, pipeline, name),
                SprintType.REVIEW_SPRINT => 
                    new ReviewSprint(this, scrumMaster, pipeline, name),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
