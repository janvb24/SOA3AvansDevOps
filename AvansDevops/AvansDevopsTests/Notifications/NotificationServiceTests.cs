using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem;

namespace AvansDevopsTests.Notifications {
    public class NotificationServiceTests {
        [Fact]
        public void ShouldSendNotificationToEachUserInList() {
            //Arrange
            INotificationService service = new NotificationService();
            var strategy = Substitute.For<ISendNotificationStrategy>();
            service.SetStrategy(strategy);
            List<User> users =
            [
                new User("", "", ""),
                new User("", "", ""),
                new User("", "", ""),
            ];
            string message = "Test message";

            //Act
            service.Send(users, message);

            //Assert
            strategy.Received(3).Send(Arg.Any<User>(), message);
        }
    }
}
