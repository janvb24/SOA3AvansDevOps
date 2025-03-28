using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.ProjectManagementSystem.forum;
using AvansDevops.SoftwareConfigurationManagement;
using AvansDevops.Notifications;

namespace AvansDevops.ProjectManagementSystem
{
    public class Project {
        private readonly IGitVersionControl _versionControl;
        public Backlog projectBacklog { get; set; } = new Backlog();
        public List<User> developers { get; }
        public User tester { get; set; }
        public User leadDeveloper { get; set; }
        public User productOwner { get; set; }
        public Forum forum { get; set; } = new Forum();
        public Sprint? currentSprint { get; private set; }
        public INotificationService notificationService { get; set; }

        public Project(IGitVersionControl versionControl, List<User> developers, User tester, User leadDeveloper, User productOwner, INotificationService notificationService)
        {
            if (developers.Count == 0) throw new ArgumentException("There must be at least 1 developer");
            
            _versionControl = versionControl;
            this.developers = developers;
            this.tester = tester;
            this.leadDeveloper = leadDeveloper;
            this.productOwner = productOwner;
            this.notificationService = notificationService;
        }

        /// <summary>
        /// Add an extra developer to the project
        /// </summary>
        /// <param name="developer">The developer to be added</param>
        public void AddDeveloper(User developer) => developers.Add(developer);
        
        /// <summary>
        /// Remove a developer from the project
        /// </summary>
        /// <param name="developer">Developer to be removed</param>
        /// <exception cref="ArgumentException">Thrown when trying to remove the last developer</exception>
        /// <exception cref="ArgumentException">Thrown when trying to remove a non-existent developer</exception>
        public void RemoveDeveloper(User developer) {
            if (developers.Count < 2) throw new ArgumentException("There must be at least 1 developer"); 
                        
            bool hasBeenRemoved = developers.Remove(developer);
            if (!hasBeenRemoved) throw new ArgumentException("This developer does not participate with the project");
        }
        
        /// <summary>
        /// Method to create a new sprint
        /// </summary>
        /// <param name="scrumMaster">The scrum master to be assigned</param>
        /// <param name="pipeline">The pipeline to be run when finishing the sprint</param>
        /// <param name="name">The name of the sprint</param>
        /// <param name="type">The type of the sprint</param>
        /// <exception cref="Exception">Thrown when there is already an active sprint</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when it does not match any sprint type</exception>
        public void NewSprint(User scrumMaster, Pipeline pipeline, string name, SprintType type)
        {
            if (currentSprint != null) throw new Exception("There should not be an active sprint running"); 
            
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
