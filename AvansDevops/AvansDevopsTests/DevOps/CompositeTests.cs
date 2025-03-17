using AvansDevops.DevOps;

namespace AvansDevopsTests.DevOps;

public class CompositeTests
{
    [Fact]
    public void ShouldAddComponent()
    {
        // Arrange
        var composite = new Composite();
        var component1 = Substitute.For<Component>();
        var component2 = Substitute.For<Component>();
        
        // Act
        composite.Add(component1);
        composite.Add(component2);
        
        // Assert
        Assert.Equal(component1, composite.GetChild(0));
        Assert.Equal(component2, composite.GetChild(1));
    }
    
    [Fact]
    public void ShouldGetComponent()
    {
        // Arrange
        var composite = new Composite();
        var component = Substitute.For<Component>();
        
        // Act
        composite.Add(component);
        
        // Assert
        Assert.Equal(component, composite.GetChild(0));
    }

    [Fact]
    public void ShouldFailWhenChildDoesNotExistOnGetChild()
    {
        // Arrange
        var composite = new Composite();
        
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => composite.GetChild(0));
    }
}