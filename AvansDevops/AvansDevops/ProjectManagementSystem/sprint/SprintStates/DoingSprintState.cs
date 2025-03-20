namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates;

public class DoingSprintState(Sprint sprint) : ISprintState
{
    public void StartSprint()
    {
        Console.WriteLine("Sprint has already been started");
    }

    public void FinishSprint()
    {
        // TODO: Sprint needs to go to new FinishedSprintState
        Console.WriteLine("Sprint has been finished");
    }

    public void CloseSprint()
    {
        Console.WriteLine("Sprint can not be closed during the doing state");
    }
}