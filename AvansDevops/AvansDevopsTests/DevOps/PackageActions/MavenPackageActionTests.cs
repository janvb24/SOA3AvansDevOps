using AvansDevops.DevOps.PackageActions;

namespace AvansDevopsTests.DevOps.PackageActions;

public class MavenPackageActionTests
{
    [Fact]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var action = new MavenPackageAction("https://www.google.com");

        // Act
        var result = action.GetPackage();

        // Assert
        Assert.True(result);
    }
}