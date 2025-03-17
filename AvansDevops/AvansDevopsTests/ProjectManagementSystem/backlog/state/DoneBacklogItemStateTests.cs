using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog.state;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem;

namespace AvansDevopsTests.ProjectManagementSystem.backlog.state {
    public class DoneBacklogItemStateTests {
        [Fact]
        public void ApproveDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var state = new DoneBacklogItemState(backlogItem);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Approve();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void CompleteDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var state = new DoneBacklogItemState(backlogItem);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Complete();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void DenyDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var state = new DoneBacklogItemState(backlogItem);
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
            var state = new DoneBacklogItemState(backlogItem);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Start();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }
    }
}
