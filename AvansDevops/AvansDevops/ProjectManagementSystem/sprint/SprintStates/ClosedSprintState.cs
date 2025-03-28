namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates {
    public class ClosedSprintState : ISprintState {
        public void ApproveSprint() {
            Console.WriteLine("Sprint has already been finished");
        }

        public void DenySprint() {
            Console.WriteLine("Sprint has already been finished");

        }

        public void FinishSprint() {
            Console.WriteLine("Sprint has already been finished");
        }

        public void StartSprint() {
            Console.WriteLine("Sprint has already been finished");
        }
    }
}
