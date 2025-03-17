using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.backlog.state;

namespace AvansDevopsTests.ProjectManagementSystem.backlog.state {
    public class TestedBacklogItemStateTests {
        [Fact]
        public void ApproveDoesChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new TestedBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Approve();

            // Assert
            Assert.Equal(backlogItem.doneState, backlogItem.currentState);
        }

        [Fact]
        public void CompleteDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new TestedBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Complete();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void DenyDoesChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new TestedBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Deny();

            // Assert
            Assert.Equal(backlogItem.readyForTestingState, backlogItem.currentState);
            notificationService.Received(1).Send(testers, "Backlog item is denied, switched back to testing");
        }

        [Fact]
        public void StartDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new TestedBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Start();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }
    }
}
