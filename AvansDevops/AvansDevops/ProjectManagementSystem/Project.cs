using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevops.ProjectManagementSystem
{
    public class Project {
        private readonly IGitVersionControl _versionControl;
        public Backlog projectBacklog { get; set; } = new Backlog();  
        public List<User> testers { get; set; } = new List<User>();
        public User leadDeveloper { get; set; }
        public Sprint currentSprint { get; private set; }

        public Project(IGitVersionControl versionControl, User leadDeveloper) {
            _versionControl = versionControl;
            this.leadDeveloper = leadDeveloper;
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
