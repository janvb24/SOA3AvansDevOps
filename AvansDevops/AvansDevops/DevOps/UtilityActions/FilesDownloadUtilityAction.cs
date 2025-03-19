namespace AvansDevops.DevOps.UtilityActions;

public class FilesDownloadUtilityAction(string context) : UtilityAction(context)
{
    
    public override bool RunUtilityAction()
    {
        Console.WriteLine($"Downloading file from {context}");
        return true;
    }
    
}