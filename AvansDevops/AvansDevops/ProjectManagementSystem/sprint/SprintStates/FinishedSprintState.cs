using AvansDevops.DevOps;

namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates {
    public class FinishedSprintState(Sprint sprint) : ISprintState {
        public void CloseSprint(bool approve) {
            if (approve) {
                // Run Pipeline
                StartPipeline();
            } else {
                // send message to PO annd SCRUM master and update state
                sprint.project.notificationService.Send([sprint.project.productOwner, sprint.scrumMaster], "Sprint has not been approved");
            }

            // update sprint state
            sprint.approved = approve;
            sprint.sprintState = new ClosedSprintState();
        }

        public void StartPipeline() {
            if (sprint is not ReleaseSprint) {
                return;
            }

            IPipelineVisitor visitor = new RunPipelineVisitor();
            bool success = sprint.pipeline.Accept(visitor);

            //TODO: use success for other user story
        }

        public void FinishSprint() {
            Console.WriteLine("Sprint has already been finished");
        }

        public void StartSprint() {
            Console.WriteLine("Sprint has already been finished");
        }
    }
}
