using AvansDevops.DevOps;
using AvansDevops.DevOps.DeployActions;
using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.report;
using AvansDevops.ProjectManagementSystem.sprint;
using AvansDevops.SoftwareConfigurationManagement;

namespace AvansDevopsTests.ProjectManagementSystem.report {
    public class ReportTests {
        [Fact]
        public void TestGenerateReport() {
            // Arrange
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var leadDev = new User("Lead", "", "");
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, leadDev, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("scrum", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster, developer));

            // Act
            var result = sprint.report.GenerateReport();

            // Assert
            string shouldBeResult =
                ".............\n" +
                "Sprint header\n" +
                ".............\n\r\n" +
                "Sprint report: name\r\n" +
                "From 01/01/0001 00:00:00 to 01/01/0001 00:00:00" +
                "\r\n\r\nTeam" +
                "\r\nDeveloper: Dev. Amount of Storypoints: 1" +
                "\r\nLead Developer: Lead\r\n" +
                "Scrum master: scrum\r\n\r\n" +
                "Burndown chart\r\n--------------------\r\n" +
                "IMG OF BURNDOWNCHART\r\n--------------------\r\n\r\n" +
                ".............\n" +
                "Sprint footer\n" +
                ".............\r\n";
            Assert.Equal(shouldBeResult, result);
        }

        [Fact]
        public void TestGenerateTitleForReviewTypeOfSprint() {
            // Arrange
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var leadDev = new User("", "", "");
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, leadDev, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            Sprint sprint = new ReviewSprint(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster));

            // Act
            var result = sprint.report.GenerateTitle();

            // Assert
            string shouldBeResult = "Review sprint report: name\r\nFrom 01/01/0001 00:00:00 to 01/01/0001 00:00:00\r\n";
            Assert.Equal(shouldBeResult, result);
        }

        [Fact]
        public void TestGenerateTitleForReleaseTypeOfSprint() {
            // Arrange
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var leadDev = new User("", "", "");
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, leadDev, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            pipeline.GetActions().Returns([new AzureDeployAction("test")]);
            Sprint sprint = new ReleaseSprint(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster));

            // Act
            var result = sprint.report.GenerateTitle();

            // Assert
            string shouldBeResult = "Release sprint report: name\r\nFrom 01/01/0001 00:00:00 to 01/01/0001 00:00:00\r\n";
            Assert.Equal(shouldBeResult, result);
        }

        [Fact]
        public void TestGenerateTitleForOtherTypeOfSprint() {
            // Arrange
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, developer, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster));

            // Act
            var result = sprint.report.GenerateTitle();

            // Assert
            string shouldBeResult = "Sprint report: name\r\nFrom 01/01/0001 00:00:00 to 01/01/0001 00:00:00\r\n";
            Assert.Equal(shouldBeResult, result);
        }

        [Fact]
        public void TestGenerateTeamLayout() {
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var leadDev = new User("Lead", "", "");
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, leadDev, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("scrum", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster, developer));

            // Act
            var result = sprint.report.GenerateTeamLayout();
            Console.WriteLine(result);

            // Assert
            string shouldBeResult = "Developer: Dev. Amount of Storypoints: 1\r\nLead Developer: Lead\r\nScrum master: scrum\r\n";
            Assert.Equal(shouldBeResult, result);
        }

        [Fact]
        public void TestGenerateBurndownChart() {
            IGitVersionControl git = Substitute.For<IGitVersionControl>();
            var developer = new User("Dev", "", "");
            var project = new Project(git, [developer], developer, developer, developer, Substitute.For<INotificationService>());
            User scrumMaster = new User("scrum", "", "");
            Pipeline pipeline = Substitute.For<Pipeline>();
            Sprint sprint = new SprintMock(project, scrumMaster, pipeline, "name");
            sprint.backlog.AddBacklogItem(new BacklogItemMock("Test", 1, scrumMaster, scrumMaster, developer));

            // Act
            var result = sprint.report.GenerateBurndownChart();
            Console.WriteLine(result);

            // Assert
            string shouldBeResult = "--------------------\r\nIMG OF BURNDOWNCHART\r\n--------------------\r\n";
            Assert.Equal(shouldBeResult, result);
        }
    }

    internal class SprintMock(Project project, User scrumMaster, Pipeline pipeline, string name, ReportTemplate? reportTemplate = null) : Sprint(project, scrumMaster, pipeline, name, reportTemplate) {
    }

    internal class BacklogItemMock(string title, int storyPoints, User tester, User scrumMaster, User? developer = null, List<BacklogItem>? subTasks = null, BacklogItem? parent = null) : BacklogItem(title, storyPoints, developer, tester, scrumMaster, subTasks, parent) {
    }
}
