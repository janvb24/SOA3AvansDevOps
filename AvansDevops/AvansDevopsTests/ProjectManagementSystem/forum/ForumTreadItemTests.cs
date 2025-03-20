
using AvansDevops.ProjectManagementSystem;
using AvansDevops.ProjectManagementSystem.forum;

namespace AvansDevopsTests.ProjectManagementSystem.forum {
    public class ForumTreadItemTests {
        readonly User user = new("User1", "", "");
        readonly User user2 = new User("User2", "", "");
        [Fact]
        public void SetNextTreadItemWillSet() {
            // Arrange
            var item = new ForumTreadItem("content", user);

            // Act
            var newItem = new ForumTreadItem("extra content", user);
            item.nextTreadItem = newItem;

            // Assert
            Assert.Equal(item.nextTreadItem, newItem);
        }

        [Fact]
        public void SetNextTreadUsesRecursionToSetIfAlreadSet() {
            // Arrange
            var item = new ForumTreadItem("content", user);
            item.nextTreadItem = new ForumTreadItem("content", user);

            // Act
            var newItem = new ForumTreadItem("extra content", user);
            item.nextTreadItem = newItem;

            // Assert
            Assert.Equal(item.nextTreadItem.nextTreadItem, newItem);
        }

        [Fact]
        public void ToStringWillFormatCorrectly() {
            // Arrange
            var item = new ForumTreadItem("Content 1", user);

            // Act
            item.nextTreadItem = new ForumTreadItem("Content 2", user2);
            item.nextTreadItem = new ForumTreadItem("Content 3", user);
            item.nextTreadItem = new ForumTreadItem("Content 4", user2);


            // Assert
            Assert.Equal(item.ToString(), "User1: Content 1\nUser2: Content 2\nUser1: Content 3\nUser2: Content 4");
        }
    }
}
