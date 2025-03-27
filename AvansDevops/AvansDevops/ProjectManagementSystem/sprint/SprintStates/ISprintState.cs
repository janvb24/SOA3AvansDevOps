namespace AvansDevops.ProjectManagementSystem.sprint.SprintStates;

public interface ISprintState
{
    /// <summary>
    /// Start the sprint
    /// </summary>
    public void StartSprint();
    
    /// <summary>
    /// Finish the sprint
    /// </summary>
    public void FinishSprint();
    
    /// <summary>
    /// Close the sprint
    /// </summary>
    public void CloseSprint(bool approve);
}