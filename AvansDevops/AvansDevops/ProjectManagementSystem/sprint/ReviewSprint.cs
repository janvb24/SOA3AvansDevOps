using AvansDevops.DevOps;

namespace AvansDevops.ProjectManagementSystem.sprint;

public class ReviewSprint(Project project, User scrumMaster, Pipeline pipeline, string name) :
    Sprint(project, scrumMaster, pipeline, name)
{
    public bool summaryAdded { get; private set; }
    public bool runPipelineOnApproval { get; set; } = true;
    
    /// <summary>
    /// Saves a summary as PDF
    /// </summary>
    /// <param name="fileLocation">File location of PDF to be saved</param>
    /// <exception cref="FileLoadException">Thrown when file is not a PDF</exception>
    public void SaveSummaryPdf(string fileLocation)
    {
        var fileExtension = fileLocation.Split(".").Last();
        if (!fileExtension.Equals("pdf")) throw new FileLoadException("File type should be pdf");

        var fileName = fileLocation.Split("\\").Last();
        var filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        File.WriteAllText(filePath, "Dummy text...");
        summaryAdded = true;
        Console.WriteLine($"{fileName} saved");
    }
}