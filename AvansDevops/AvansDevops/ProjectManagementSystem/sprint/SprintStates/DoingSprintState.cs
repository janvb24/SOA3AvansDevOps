namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates;

public class DoingSprintState(Sprint sprint) : ISprintState {
    public void StartSprint()
    {
        Console.WriteLine("Sprint has already been started");
    }

    public void FinishSprint()
    {
        // TODO: Sprint needs to go to new FinishedSprintState
        Console.WriteLine("Sprint has been finished");
    }

    public void ApproveSprint() {
        Console.WriteLine("Sprint has not been finished yet");
    }

    public void DenySprint() {
        Console.WriteLine("Sprint has not been finished yet");
    
    }
}