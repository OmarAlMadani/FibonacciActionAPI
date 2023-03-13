using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FibonacciActionAPITest
{
    public class FibonacciControllerTests : IClassFixture<WebApplicationFactory<FibonacciActionAPI.Startup>>
    {
        private readonly HttpClient _client;

        public FibonacciControllerTests(WebApplicationFactory<FibonacciActionAPI.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetFibonacci_ReturnsBadRequest_WhenNIsLessThanOne()
        {
            // Arrange
            var n = 0;

            // Act
            var response = await _client.GetAsync($"/fibonacci/{n}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetFibonacci_ReturnsBadRequest_WhenNIsGreaterThan100()
        {
            // Arrange
            var n = 101;

            // Act
            var response = await _client.GetAsync($"/fibonacci/{n}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetFibonacci_ReturnsCorrectValue_WhenNIsValid()
        {
            // Arrange
            var n = 7;
            var expectedValue = 13;

            // Act
            var response = await _client.GetAsync($"/fibonacci/{n}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var actualValue = JsonSerializer.Deserialize<int>(responseBody);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedValue, actualValue);
        }
    }

}