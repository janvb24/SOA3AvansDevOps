namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates;

public class CreatedSprintState(Sprint sprint) : ISprintState
{
    public void StartSprint()
    {
        if (sprint.GetBacklogItems().Count == 0) throw new ArgumentException("Sprint backlog must not be empty");
        
        sprint.beginDateTime = DateTime.Now;
        sprint.sprintState = new DoingSprintState(sprint);
        sprint.editable = false;
        Console.WriteLine("Sprint has been started");
    }

    public void FinishSprint()
    {
        Console.WriteLine("Sprint can not be finished while in created state");
    }

    public void ApproveSprint() {
        Console.WriteLine("Sprint has not been finished yet");
    }

    public void DenySprint() {
        Console.WriteLine("Sprint has not been finished yet");

    }

}