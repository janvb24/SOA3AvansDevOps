namespace AvansDevops.DevOps;

public class RunPipelineVisitor : IPipelineVisitor
{
    
    /// <summary>
    /// Run's the pipeline that is being visited
    /// </summary>
    /// <param name="pipeline">The pipeline to be visited</param>
    public void VisitPipeline(Pipeline pipeline)
    {
        Console.WriteLine("Running pipeline");
    }
    
}