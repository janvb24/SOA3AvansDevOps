namespace AvansDevops.DevOps;

public class RunPipelineVisitor : IPipelineVisitor
{
    
    public void VisitPipeline(Pipeline pipeline)
    {
        Console.WriteLine("Running pipeline");
    }
    
}