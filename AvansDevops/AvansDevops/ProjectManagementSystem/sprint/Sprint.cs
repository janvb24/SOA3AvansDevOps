using AvansDevops.DevOps;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.report;
using AvansDevops.ProjectManagementSystem.sprint.SprintStates;

namespace AvansDevops.ProjectManagementSystem.sprint;

public abstract class Sprint
{
    private const string UNEDITABLE_EXCEPTION = "The value can not be edited because the sprint has started";
    
    private string _name;
    private DateTime _beginDateTime;
    private DateTime _endDateTime;
    private Project _project;
    private User _scrumMaster;
    private IPipeline _pipeline;
    public Backlog backlog;
    public Report report;

    public string name
    {
        get => _name;
        set => _name = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }
    
    public DateTime beginDateTime
    {
        get => _beginDateTime;
        set => _beginDateTime = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }
    
    public DateTime endDateTime
    {
        get => _endDateTime;
        set => _endDateTime = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }

    public Project project
    {
        get => _project;
        set => _project = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }

    public User scrumMaster
    {
        get => _scrumMaster;
        set => _scrumMaster = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }

    public IPipeline pipeline
    {
        get => _pipeline;
        set => _pipeline = editable ? value : throw new ArgumentException(UNEDITABLE_EXCEPTION);
    }

    public ISprintState sprintState { get; set; }
    public bool editable { get; set; }

    protected Sprint(Project project, User scrumMaster, IPipeline pipeline, string name, ReportTemplate? reportTemplate = null)
    {
        _project = project;
        _scrumMaster = scrumMaster;
        _pipeline = pipeline;
        _name = name;
        _beginDateTime = beginDateTime;
        _endDateTime = endDateTime;

        backlog = new Backlog();
        sprintState = new CreatedSprintState(this);
        editable = true;
        reportTemplate = reportTemplate ?? new ReportTemplate(
            ".............\nSprint header\n.............\n", 
            ".............\nSprint footer\n.............");
        report = new Report(this, reportTemplate);
    }

    /// <summary>
    /// Add a backlog item to the sprint backlog
    /// </summary>
    /// <param name="backlogItem">Backlog item to be added</param>
    /// <exception cref="ArgumentException">Throws exception when backlog item is a subtask or sprint is not editable</exception>
    public void AddToBacklog(BacklogItem backlogItem)
    {
        if (!editable) throw new ArgumentException(UNEDITABLE_EXCEPTION);
        if (backlogItem.parent != null) throw new ArgumentException("Backlog item cannot be a subtask");
        backlog.AddBacklogItem(backlogItem);
    }

    /// <summary>
    /// Get backlog items
    /// </summary>
    /// <returns>Backlog items</returns>
    public List<BacklogItem> GetBacklogItems()
    {
        return backlog.GetBacklogItems();
    }

    /// <summary>
    /// Start the sprint
    /// </summary>
    public void StartSprint() => sprintState.StartSprint();
    
    /// <summary>
    /// Finish the sprint
    /// </summary>
    public void FinishSprint() => sprintState.FinishSprint();
    
    /// <summary>
    /// Close the sprint
    /// </summary>
    public void CloseSprint() => sprintState.CloseSprint();
}