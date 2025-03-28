namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates;

public class DoingSprintState : ISprintState
{
    private readonly Sprint _sprint;
    private readonly Timer _finishSprintTimer;

    public DoingSprintState(Sprint sprint)
    {
        _sprint = sprint;
        
        // Set timer that finishes sprint when endDateTime in sprint has been reached
        TimeSpan delay = _sprint.endDateTime - DateTime.Now;
        _finishSprintTimer = new Timer(_ => FinishSprint(), null, delay, Timeout.InfiniteTimeSpan);
    }

    public void StartSprint()
    {
        Console.WriteLine("Sprint has already been started");
    }

    public void FinishSprint()
    {
        _finishSprintTimer.Dispose();
        _sprint.PersistBacklog();
        _sprint.sprintState = new FinishedSprintState(_sprint);
        Console.WriteLine("Sprint has been finished");
    }

    public void CloseSprint()
    {
        Console.WriteLine("Sprint can not be closed during the doing state");
    }
}