using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevopsTests.ProjectManagementSystem.backlog {
    public class BacklogItemTests {
        [Fact]
        public void SubTaskCannotBeSetIfParentHasValue() {
            // Arrange
            BacklogItem parent = new EditableBacklogItem("Title", 1);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, parent: parent);

            // Act
            Exception? e = null;
            try {
                backlogItem.subTasks = [];
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Null(backlogItem.subTasks);
            Assert.NotNull(e);
            Assert.Equal("Subtask cannot contain subtasks", e!.Message);
        }

        [Fact]
        public void SubTaskCanBeSetIfParentHasNoValue() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                backlogItem.subTasks = new List<BacklogItem>();
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.NotNull(backlogItem.subTasks);
            Assert.Null(e);
        }

        [Fact]
        public void ParentCannotBeSetIfSubTaskHasValue() {
            // Arrange
            BacklogItem parent = new EditableBacklogItem("Title", 1);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                backlogItem.parent = parent;
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Null(backlogItem.parent);
            Assert.NotNull(e);
            Assert.Equal("Backlog item cannot become subtask", e!.Message);
        }

        [Fact]
        public void ParentCanBeSetIfSubTaskHasNoValue() {
            // Arrange
            BacklogItem parent = new EditableBacklogItem("Title", 1);
            BacklogItem parentNew = new EditableBacklogItem("Title", 1);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, parent: parent);


            // Act
            Exception? e = null;
            try {
                backlogItem.parent = parentNew;
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Equal(parentNew, backlogItem.parent);
            Assert.Null(e);
        }

        [Fact]
        public void ConstructorMakesSubTasksNullIfParentHasValue() {
            // Arrange
            BacklogItem parent = new EditableBacklogItem("Title", 1);

            // Act
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, parent: parent);

            // Assert
            Assert.Equal(parent, backlogItem.parent);
            Assert.Null(backlogItem.subTasks);
        }

        [Fact]
        public void ConstructorMakesParentNullIfParentHasNoValue() {
            // Arrange

            // Act
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1);

            // Assert
            Assert.Null(backlogItem.parent);
            Assert.Equal([], backlogItem.subTasks);
        }
    }
}
