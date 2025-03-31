using AvansDevops.DevOps;

namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates {
    public class FinishedSprintState(Sprint sprint) : ISprintState {
        public void ApproveSprint() {
            if (sprint is ReleaseSprint) {
                bool success = RunPipeline();

                if (success) {
                    sprint.approved = true;
                    sprint.sprintState = new ClosedSprintState();
                } else {
                    Console.WriteLine("Pipeline failed, sprint not approved");
                }

                return;
            }

            if (sprint is ReviewSprint reviewSprint) {
                if (reviewSprint.summaryAdded == false) {
                    Console.WriteLine("Summary must be added before sprint can be approved");
                    return;
                }

                if (reviewSprint.runPipelineOnApproval) {
                    bool success = RunPipeline();

                    if (success) {
                        sprint.approved = true;
                        sprint.sprintState = new ClosedSprintState();
                    } else {
                        Console.WriteLine("Pipeline failed, sprint not approved");
                    }

                    return;
                }
            }

            // update sprint state
            sprint.approved = true;
            sprint.sprintState = new ClosedSprintState();
        }

        private bool RunPipeline() {
            IPipelineVisitor visitor = new RunPipelineVisitor();
            return sprint.pipeline.Accept(visitor);
        }

        public void DenySprint() {
            // send message to PO annd SCRUM master and update state
            sprint.project.notificationService.Send([sprint.project.productOwner, sprint.scrumMaster], "Sprint has not been approved");
            sprint.approved = false;
            sprint.sprintState = new ClosedSprintState();
        }

        public void FinishSprint() {
            Console.WriteLine("Sprint has already been finished");
        }

        public void StartSprint() {
            Console.WriteLine("Sprint has already been finished");
        }
    }
}
