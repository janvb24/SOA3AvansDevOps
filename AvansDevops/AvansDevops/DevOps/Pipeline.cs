namespace AvansDevops.DevOps;

public abstract class Pipeline : Composite {
    /// <summary>
    /// Method to fetch all the child actions of the pipeline
    /// </summary>
    /// <returns>Pipeline actions as a Component</returns>

    abstract public List<Component> GetActions();
}