namespace AvansDevops.DevOps.AnalysisActions;

public abstract class AnalysisAction : Component
{
    
    public override bool Accept(IPipelineVisitor visitor)
    {
        return visitor.VisitAnalysisAction(this);
    }

    /// <summary>
    /// Method to run analysis
    /// </summary>
    /// <returns>True if analysis went successfully, False if not</returns>
    public abstract bool RunAnalysis();

}