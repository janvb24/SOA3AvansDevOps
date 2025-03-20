namespace AvansDevops.DevOps;

public class Composite : Component
{
    
    protected readonly List<Component> parts = [];
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return parts.All(part => part.Accept(visitor));
    }

    /// <summary>
    /// Add an action to the pipeline.
    /// </summary>
    /// <param name="component">A new action</param>
    public void Add(Component component)
    {
        parts.Add(component);
    }
    
    /// <summary>
    /// Returns the action at the given index from the pipeline.
    /// </summary>
    /// <param name="index">Index of the action</param>
    /// <returns>The action in the pipeline</returns>
    public Component GetChild(int index)
    {
        return parts[index];
    }
    
}