using AvansDevops.DevOps;

namespace AvansDevops.ProjectManagementSystem.sprint;

public class ReviewSprint(Project project, User scrumMaster, Pipeline pipeline, string name) : 
    Sprint(project, scrumMaster, pipeline, name);