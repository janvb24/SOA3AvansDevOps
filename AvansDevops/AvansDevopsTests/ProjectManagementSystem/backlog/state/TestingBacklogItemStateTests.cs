using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.backlog.state;

namespace AvansDevopsTests.ProjectManagementSystem.backlog.state {
    public class TestingBacklogItemStateTests {
        [Fact]
        public void ApproveDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            User leadDeveloper = new User("", "", "");
            User scrumMaster = new User("", "", "");
            var state = new TestingBacklogItemState(backlogItem, notificationService, leadDeveloper, scrumMaster);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Approve();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void CompleteDoesChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            User leadDeveloper = new User("", "", "");
            User scrumMaster = new User("", "", "");
            var state = new TestingBacklogItemState(backlogItem, notificationService, leadDeveloper, scrumMaster);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Complete();

            // Assert
            Assert.Equal(backlogItem.testedState, backlogItem.currentState);
            notificationService.Received(1)
                .Send(Arg.Any<List<User>>(), "Backlog item is completed, switch to complete");
        }

        [Fact]
        public void DenyDoesChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            User leadDeveloper = new User("", "", "");
            User scrumMaster = new User("", "", "");
            var state = new TestingBacklogItemState(backlogItem, notificationService, leadDeveloper, scrumMaster);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Deny();

            // Assert
            Assert.Equal(backlogItem.todoState, backlogItem.currentState);
            notificationService.Received(1).Send(Arg.Any<List<User>>(), "Backlog item is denied, switch to to do");
        }

        [Fact]
        public void StartDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            User leadDeveloper = new User("", "", "");
            User scrumMaster = new User("", "", "");
            var state = new TestingBacklogItemState(backlogItem, notificationService, leadDeveloper, scrumMaster);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Start();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }
    }
}
