using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.backlog.state;

namespace AvansDevopsTests.ProjectManagementSystem.backlog.state {
    public class DoingBacklogItemStateTests {
        [Fact]
        public void ApproveDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new DoingBacklogItemState(backlogItem, notificationService, testers);
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
            List<User> testers = [new User("", "", "")];
            var state = new DoingBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Complete();

            // Assert
            Assert.Equal(backlogItem.readyForTestingState, backlogItem.currentState);
            notificationService.Received().Send(testers, "Backlog item is ready for testing");
        }

        [Fact]
        public void DenyDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new DoingBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Deny();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void StartDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var notificationService = NSubstitute.Substitute.For<INotificationService>();
            List<User> testers = [new User("", "", "")];
            var state = new DoingBacklogItemState(backlogItem, notificationService, testers);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Start();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }
    }
}
