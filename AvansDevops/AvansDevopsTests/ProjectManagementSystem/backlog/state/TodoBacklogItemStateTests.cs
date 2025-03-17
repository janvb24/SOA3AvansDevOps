using AvansDevops.ProjectManagementSystem.backlog.state;
using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevopsTests.ProjectManagementSystem.backlog.state {
    public class TodoBacklogItemStateTests {
        [Fact]
        public void ApproveDoesNotChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var state = new TodoBacklogItemState(backlogItem);
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
            var state = new TodoBacklogItemState(backlogItem);
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
            var state = new TodoBacklogItemState(backlogItem);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Deny();

            // Assert
            Assert.Equal(state, backlogItem.currentState);
        }

        [Fact]
        public void StartDoesChangeCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);
            var state = new TodoBacklogItemState(backlogItem);
            backlogItem.currentState = state;

            // Act
            backlogItem.currentState.Start();

            // Assert
            Assert.Equal(backlogItem.doingState, backlogItem.currentState);
        }
    }
}
