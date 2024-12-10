using Bunit;
using Moq;
using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;
using KraftKollen.Components.Components;
using KraftKollen.Components.View.Pages;
using KraftKollen.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace KraftKollen.Tests
{


    public class CompareTwoRegionsOutputTests
    {
        [Fact]
        public async Task DisplaysEqualsWhenValuesAreEqualAsync()
        {
            // Arrange
            using var context = new BunitContext();

            // Mock the IApiService
            var mockApiService = new Mock<IApiService>();
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2020"))
                .ReturnsAsync(new WindPowerProduction { Value = 500 });
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2021"))
                .ReturnsAsync(new WindPowerProduction { Value = 500 });

            // Mock the IYearComparisonIndicator
            var mockYearComparisonIndicator = new Mock<IYearComparisonIndicator>();
            mockYearComparisonIndicator
                .Setup(indicator => indicator.GetYearComparisonIndicator(500, 500))
                .Returns("Equal");

            context.Services.AddSingleton(mockApiService.Object);
            context.Services.AddSingleton(mockYearComparisonIndicator.Object);

            // Render the component
            var component = context.Render<CompareTwoRegionsOutputView>();

            // Act
            // Simulate selecting two years
            await component.InvokeAsync(() =>
                component.FindComponent<GetTwoYearsComponent>().Instance.OnTwoYearsSelected.InvokeAsync((2020, 2021))
            );

            // Assert
            // Verify the displayed arrow and class
            var arrowElement = component.Find("h3.alert-info");
            Assert.Equal(" = ", arrowElement.TextContent);
        }

        [Fact]
        public async Task DisplaysLeftArrowWhenFirstYearValueIsGreaterThanSecondYearValue()
        {
            // Arrange
            using var context = new BunitContext();

            // Mock the IApiService
            var mockApiService = new Mock<IApiService>();
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2020"))
                .ReturnsAsync(new WindPowerProduction { Value = 600 }); // Larger value for 2020
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2021"))
                .ReturnsAsync(new WindPowerProduction { Value = 400 }); // Smaller value for 2021

            // Mock the IYearComparisonIndicator
            var mockYearComparisonIndicator = new Mock<IYearComparisonIndicator>();
            mockYearComparisonIndicator
                .Setup(indicator => indicator.GetYearComparisonIndicator(600, 400))
                .Returns("Left"); // Simulate comparison logic

            context.Services.AddSingleton(mockApiService.Object);
            context.Services.AddSingleton(mockYearComparisonIndicator.Object);

            // Render the component
            var component = context.Render<CompareTwoRegionsOutputView>();

            // Act
            // Simulate selecting two years within InvokeAsync
            await component.InvokeAsync(() =>
                component.FindComponent<GetTwoYearsComponent>().Instance.OnTwoYearsSelected.InvokeAsync((2020, 2021))
            );

            // Assert
            // Verify the displayed arrow and class
            var arrowElement = component.Find("h3.alert-danger");
            Assert.Equal(" ← ", arrowElement.TextContent); // Check for the left arrow
        }

        [Fact]
        public async Task DisplaysRightArrowWhenSecondYearValueIsGreaterThanFirstYearValue()
        {
            // Arrange
            using var context = new BunitContext();

            // Mock the IApiService
            var mockApiService = new Mock<IApiService>();
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2020"))
                .ReturnsAsync(new WindPowerProduction { Value = 300 }); // Smaller value for 2020
            mockApiService
                .Setup(service => service.GetWindPowerProduction(It.IsAny<string>(), "2021"))
                .ReturnsAsync(new WindPowerProduction { Value = 500 }); // Larger value for 2021

            // Mock the IYearComparisonIndicator
            var mockYearComparisonIndicator = new Mock<IYearComparisonIndicator>();
            mockYearComparisonIndicator
                .Setup(indicator => indicator.GetYearComparisonIndicator(300, 500))
                .Returns("Right"); // Simulate comparison logic

            context.Services.AddSingleton(mockApiService.Object);
            context.Services.AddSingleton(mockYearComparisonIndicator.Object);

            // Render the component
            var component = context.Render<CompareTwoRegionsOutputView>();

            // Act
            // Simulate selecting two years within InvokeAsync
            await component.InvokeAsync(() =>
                component.FindComponent<GetTwoYearsComponent>().Instance.OnTwoYearsSelected.InvokeAsync((2020, 2021))
            );

            // Assert
            // Verify the displayed arrow and class
            var arrowElement = component.Find("h3.alert-success");
            Assert.Equal(" → ", arrowElement.TextContent); // Check for the right arrow
        }
    }
}

