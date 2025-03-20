using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.forum;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevops.ProjectManagementSystem
{
    public class Project {
        private readonly IGitVersionControl _versionControl;
        public Backlog projectBacklog { get; set; } = new Backlog();  
        public List<User> testers { get; set; } = new List<User>();
        public User leadDeveloper { get; set; }

        public Project(IGitVersionControl versionControl, User leadDeveloper) {
            _versionControl = versionControl;
            this.leadDeveloper = leadDeveloper;
        }
    }
}
