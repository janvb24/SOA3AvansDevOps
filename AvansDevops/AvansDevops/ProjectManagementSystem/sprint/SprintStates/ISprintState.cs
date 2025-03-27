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
    /// Approves the sprint
    /// </summary>
    public void ApproveSprint();


    /// <summary>
    /// Denies the sprint
    /// </summary>
    public void DenySprint();
}