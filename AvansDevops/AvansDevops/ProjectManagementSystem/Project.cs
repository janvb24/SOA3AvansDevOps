using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevops.ProjectManagementSystem
{
    public class Project {
        private readonly IGitVersionControl _versionControl;
        public Backlog projectBacklog { get; set; } = new Backlog();        
        public Project(IGitVersionControl versionControl) {
            _versionControl = versionControl;
        }
    }
}
