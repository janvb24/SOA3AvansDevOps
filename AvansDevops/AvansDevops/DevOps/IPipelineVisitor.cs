namespace AvansDevops.DevOps;

public interface IPipelineVisitor
{
    
    /// <summary>
    /// Function called when the pipeline is visited
    /// </summary>
    /// <param name="pipeline">The pipeline to be visited</param>
    public void VisitPipeline(Pipeline pipeline);

}