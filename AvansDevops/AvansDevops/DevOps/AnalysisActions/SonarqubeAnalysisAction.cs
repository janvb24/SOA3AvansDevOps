namespace AvansDevops.DevOps.AnalysisActions;

public class SonarqubeAnalysisAction : AnalysisAction
{
    
    public override bool RunAnalysis()
    {
        Console.WriteLine("Running Sonarqube analysis");
        return true;
    }
    
}