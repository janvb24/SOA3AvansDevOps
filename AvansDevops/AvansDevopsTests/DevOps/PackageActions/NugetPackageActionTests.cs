using AvansDevops.DevOps.PackageActions;

namespace AvansDevopsTests.DevOps.PackageActions;

public class NugetPackageActionTests
{
    [Fact]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var action = new NugetPackageAction("https://www.google.com");

        // Act
        var result = action.GetPackage();

        // Assert
        Assert.True(result);
    }
}