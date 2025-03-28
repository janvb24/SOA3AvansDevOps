using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;
using AvansDevops.ProjectManagementSystem.backlog.state;
using AvansDevops.SoftwareConfigurationManagement.GitActions.PushAction;

namespace AvansDevopsTests.ProjectManagementSystem.backlog {
    public class BacklogItemTests {
        User tester = new("", "", "");
        User scrumMaster = new("", "", "");
        [Fact]
        public void SubTaskCannotBeSetIfParentHasValue() {
            // Arrange
            BacklogItem parent = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster, parent: parent);

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
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);

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
            BacklogItem parent = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);

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
            BacklogItem parent = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            BacklogItem parentNew = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster, parent: parent);


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
            BacklogItem parent = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);

            // Act
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster, parent: parent);

            // Assert
            Assert.Equal(parent, backlogItem.parent);
            Assert.Null(backlogItem.subTasks);
        }

        [Fact]
        public void ConstructorMakesParentNullIfParentHasNoValue() {
            // Arrange

            // Act
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);

            // Assert
            Assert.Null(backlogItem.parent);
            Assert.Equal([], backlogItem.subTasks);
        }

        [Fact]
        public void StateMethodsCallsMethodFromCurrentState() {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            var stateSub = Substitute.For<IBacklogItemState>();
            backlogItem.currentState = stateSub;

            // Act
            backlogItem.Start();
            backlogItem.Approve();
            backlogItem.Deny();
            backlogItem.Complete();

            // Assert
            stateSub.Received(1).Start();
            stateSub.Received(1).Approve();
            stateSub.Received(1).Deny();
            stateSub.Received(1).Complete();
        }

        [Fact]
        public void ShouldPersistSubtasks()
        {
            // Arrange
            BacklogItem backlogItem = new EditableBacklogItem("Title", 1, null, tester, scrumMaster);
            var stateSub = Substitute.For<IBacklogItemState>();
            backlogItem.currentState = stateSub;
            List<BacklogItem> subtasks =
            [
                new EditableBacklogItem("Title", 1, null, tester, scrumMaster),
                new EditableBacklogItem("Title", 1, null, tester, scrumMaster)
            ];
            backlogItem.subTasks = subtasks;
            List<BacklogItem> expected =
            [
                new NonEditableBacklogItem("Title", 1, null, tester, scrumMaster),
                new NonEditableBacklogItem("Title", 1, null, tester, scrumMaster)
            ];

            // Act
            backlogItem.PersistSubtasks();

            // Assert
            Assert.Equivalent(backlogItem.subTasks, expected, true);
        }
    }
}
