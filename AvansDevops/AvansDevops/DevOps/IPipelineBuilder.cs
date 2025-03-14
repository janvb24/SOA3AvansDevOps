namespace AvansDevops.DevOps;

public interface IPipelineBuilder
{

    /// <summary>
    /// Builds the pipeline and returns a concrete pipeline.
    /// </summary>
    /// <returns>The concrete pipeline build with the builder.</returns>
    public Pipeline Build();

}