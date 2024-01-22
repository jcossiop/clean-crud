using Domain.Representatives;

namespace Domain.UnitTests;

public class RepresentativeTests
{
    [Fact]
    public void IsEmailValid_ShouldReturnTrue_WhenEmailIsValid()
    {
        // Arrange/Act
        var rep = new Representative { Name = "Sample Name", Email = "test@example.com" };

        // Assert
        rep.IsEmailValid().Should().BeTrue("If an email has been entered, it should be valid.");
    }
}