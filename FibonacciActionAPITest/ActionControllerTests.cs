
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FibonacciActionAPI.Tests
{
    public class ActionControllerTests
    {
        [Fact]
        public void Get_Returns_ActionInfo_With_Max_Avg_Price()
        {
            // Arrange
            var expected = new ActionInfo { Name = "GOOG", AvgPrice = 11.66 };

            // Act
            var actionResult = new ActionController().Get();
            var actual = actionResult.Value;

            // Assert
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(11.66, actionResult.Value.AvgPrice);


        }

    }
}
