namespace AvansDevops.DevOps;

public interface IPipeline
{
    /// <summary>
    /// Method to fetch all the child actions of the pipeline
    /// </summary>
    /// <returns>Pipeline actions as a Component</returns>
    public List<Component> GetActions();
}