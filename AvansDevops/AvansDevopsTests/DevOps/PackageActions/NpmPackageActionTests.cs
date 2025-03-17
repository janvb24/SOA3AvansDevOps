using AvansDevops.DevOps.PackageActions;

namespace AvansDevopsTests.DevOps.PackageActions;

public class NpmPackageActionTests
{
    [Fact]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var action = new NpmPackageAction("https://www.google.com");

        // Act
        var result = action.GetPackage();

        // Assert
        Assert.True(result);
    }
}