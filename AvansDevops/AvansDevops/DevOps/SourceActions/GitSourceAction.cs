namespace AvansDevops.DevOps.SourceActions;

public class GitSourceAction(string url) : SourceAction(url)
{
    public override bool GetSource()
    {
        Console.WriteLine($"Getting git source from {url}");
        return true;
    }
    
}