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
        public Forum forum { get; set; } = new Forum();
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

        /// <summary>
        /// Move an existing backlog item from the project backlog to the current sprint backlog.
        /// </summary>
        /// <param name="backlogItem">The backlog item to be moved</param>
        public void MoveBacklogItemToSprint(BacklogItem backlogItem)
        {
            bool removed = projectBacklog.RemoveBacklogItem(backlogItem);

            if (removed) currentSprint.AddToBacklog(backlogItem);
            else throw new ArgumentException("The backlog item does not exist in the project backlog");
        }

        /// <summary>
        /// Add a new backlog item to the current sprint.
        /// </summary>
        /// <param name="backlogItem">The backlog item to be added</param>
        public void AddNewBacklogItemToSprint(BacklogItem backlogItem)
        {
            bool inProjectBacklog = projectBacklog.GetBacklogItems().Contains(backlogItem);
            
            if (!inProjectBacklog) currentSprint.AddToBacklog(backlogItem);
            else throw new ArgumentException("The backlog item can not be in the project backlog");
        }
    }
}
