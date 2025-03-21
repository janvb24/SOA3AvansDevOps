using AvansDevops.ProjectManagementSystem.sprint;
using System.Text;

namespace AvansDevops.ProjectManagementSystem.report {
    public class Report {
        private Sprint sprintForReport;
        public ReportTemplate template { get; set;}
       
        public Report(Sprint sprintForReport, ReportTemplate template) {
            this.sprintForReport = sprintForReport;
            this.template = template;
        }

        /// <summary>
        /// Generates report based on the sprint
        /// </summary>
        public void GenerateReport() {
            StringBuilder report = new StringBuilder();

            report.AppendLine(template.header);
            report.AppendLine(this.GenerateTitle());

            report.AppendLine("Team");
            report.AppendLine(this.GenerateTeamLayout());

            report.AppendLine("Burndown chart");
            report.AppendLine(this.GenerateBurndownChart());

            report.AppendLine(template.footer);

            string fileName = sprintForReport.name + "Report.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            File.WriteAllText(filePath, report.ToString());
            Console.WriteLine($"Report saved to {filePath}");
            Console.WriteLine(report.ToString());
        }

        /// <summary>
        /// Generates title of report
        /// </summary>
        /// <returns>String value of title</returns>
        public string GenerateTitle() {
            StringBuilder title = new StringBuilder();

            if (sprintForReport is ReleaseSprint) {
                title.AppendLine("Release sprint report: " + sprintForReport.name);
            } else if (sprintForReport is ReviewSprint) {
                title.AppendLine("Review sprint report: " + sprintForReport.name);
            } else {
                title.AppendLine("Sprint report: " + sprintForReport.name);
            }
            title.AppendLine($"From {sprintForReport.beginDateTime} to {sprintForReport.endDateTime}");

            return title.ToString();
        }

        /// <summary>
        /// Generates team layout for the report
        /// </summary>
        /// <returns>String value of team layout</returns>
        public string GenerateTeamLayout() {
            StringBuilder teamLayout = new StringBuilder();
            
            //Developers with their storypoints
            foreach (User developer in sprintForReport.project.developers) {
                teamLayout.AppendLine($"Developer: {developer.name}. ");
                teamLayout.Append($"Amount of Storypoints: {this.CalcStoryPointsPerDeveloper(developer)}");
            }

            //Other team members
            teamLayout.AppendLine("Lead Developer: " + sprintForReport.project.leadDeveloper.name);
            //TODO: add testers - have to wait for TREINO to change to single tester
            teamLayout.AppendLine("Scrum master: " + sprintForReport.scrumMaster.name);
            
            return teamLayout.ToString();
        }

        /// <summary>
        /// Generates burndown chart for the report
        /// </summary>
        /// <returns>String value for burndownchart</returns>
        public string GenerateBurndownChart() {
            StringBuilder burndownChart = new StringBuilder();

            burndownChart.AppendLine("--------------------");
            burndownChart.AppendLine("IMG OF BURNDOWNCHART");
            burndownChart.AppendLine("--------------------");

            return burndownChart.ToString();
        }

        /// <summary>
        /// Calculates amount of storypoints for a developer
        /// </summary>
        /// <param name="user">The developer</param>
        /// <returns>Amount of storypoints of the developer in the sprint</returns>
        public int CalcStoryPointsPerDeveloper(User user) {
            int amount = 0;
            foreach (var backlogItem in sprintForReport.backlog.GetBacklogItems()) {
                if (backlogItem.developer == user) {
                    amount += backlogItem.storyPoints;
                }
            }
            return amount;
        }
    }
}
