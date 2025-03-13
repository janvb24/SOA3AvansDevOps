namespace AvansDevops.DevOps;

public class Composite : Component
{
    
    private readonly List<Component> _parts = [];

    public override bool Accept(IPipelineVisitor visitor)
    {
        return _parts.All(part => part.Accept(visitor));
    }

    public void Add(Component component)
    {
        _parts.Add(component);
    }
    
    public Component GetChild(int index)
    {
        return _parts[index];
    }
    
}