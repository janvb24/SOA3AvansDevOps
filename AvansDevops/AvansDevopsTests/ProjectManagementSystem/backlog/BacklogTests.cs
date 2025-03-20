using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevopsTests.ProjectManagementSystem.backlog {
    public class BacklogTests {
        User tester = new("", "", "");
        User scrumMaster = new("", "", "");
        [Fact]
        public void TestAddBacklogItem() {
            // Arrange
            var backlog = new Backlog();
            var backlogItem = new EditableBacklogItem("Test", 5, null, tester, scrumMaster);
            
            // Act
            backlog.AddBacklogItem(backlogItem);
            
            // Assert
            Assert.Contains(backlogItem, backlog.GetBacklogItems());
        }

        [Fact]
        public void TestRemoveBacklogItem() {
            // Arrange
            var backlog = new Backlog();
            var backlogItem = new EditableBacklogItem("Test", 5, null, tester, scrumMaster);
            backlog.AddBacklogItem(backlogItem);
            
            // Act
            backlog.RemoveBacklogItem(backlogItem);
            
            // Assert
            Assert.DoesNotContain(backlogItem, backlog.GetBacklogItems());
        }

        [Fact]
        public void TestGetBacklogItems() {
            // Arrange
            var backlog = new Backlog();
            var backlogItem = new EditableBacklogItem("Test", 5, null, tester, scrumMaster);
            backlog.AddBacklogItem(backlogItem);
            
            // Act
            var backlogItems = backlog.GetBacklogItems();
            
            // Assert
            Assert.Contains(backlogItem, backlogItems);
        }
    }
}
