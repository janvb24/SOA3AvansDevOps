using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevopsTests.ProjectManagementSystem.backlog {
    public class NonEditableBacklogItemTests {
        [Fact]
        public void TestChangePropertyTitleInNonEditableBacklogItem() {
            // Arrange
            BacklogItem nonEditableBacklogItem = new NonEditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                nonEditableBacklogItem.title = "New Title";
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Equal("Title", nonEditableBacklogItem.title);
            Assert.NotNull(e);
            Assert.Equal("Title cannot be altered", e!.Message);
        }

        [Fact]
        public void TestChangePropertyStoryPointsInNonEditableBacklogItem() {
            // Arrange
            BacklogItem nonEditableBacklogItem = new NonEditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                nonEditableBacklogItem.storyPoints = 5;
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Equal(1, nonEditableBacklogItem.storyPoints);
            Assert.NotNull(e);
            Assert.Equal("Story points cannot be altered", e!.Message);
        }

        [Fact]
        public void TestChangePropertSubTasksInNonEditableBacklogItem() {
            // Arrange
            BacklogItem nonEditableBacklogItem = new NonEditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                nonEditableBacklogItem.subTasks = [];
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Empty(nonEditableBacklogItem.subTasks);
            Assert.NotNull(e);
            Assert.Equal("Subtasks cannot be altered", e!.Message);
        }

        [Fact]
        public void TestChangePropertParentInNonEditableBacklogItem() {
            // Arrange
            BacklogItem nonEditableBacklogItem = new NonEditableBacklogItem("Title", 1);

            // Act
            Exception? e = null;
            try {
                nonEditableBacklogItem.parent = new EditableBacklogItem("",1);
            } catch (ArgumentException ex) {
                e = ex;
            }

            // Assert
            Assert.Null(nonEditableBacklogItem.parent);
            Assert.NotNull(e);
            Assert.Equal("Parent cannot be altered", e!.Message);
        }
    }
}
