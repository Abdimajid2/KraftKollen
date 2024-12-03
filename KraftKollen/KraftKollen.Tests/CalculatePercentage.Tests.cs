using KraftKollen.Models;
using Moq;
using KraftKollen.Repository;
using KraftKollen.Helpers;

namespace KraftKollen.Tests;

public class CalculatePercentage_Tests
{
    [Theory]
    [InlineData(1000.0, 250.0, 25.0)]
    // [InlineData(0.0, 250.0, null)] // Förväntat resultat null för att undvika division med 0
    [InlineData(1000.0, 0.0, 0.0)]
    [InlineData(500.0, 500.0, 100.0)]
    public async Task CalculatePercentageOfTotalProduction(double totalproduction, double windproction,
        double? expectedProduction)
    {
        // Arrange
        var mockapiService = new Mock<IApiService>();
        mockapiService.Setup(s => s.GetTotalPowerProduction(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new WindPowerProduction { Value = totalproduction });

        mockapiService.Setup(s => s.GetWindPowerProduction(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new WindPowerProduction { Value = windproction });

        var calculate = new CalculateProcentage(mockapiService.Object);
        // Act
        var result = await calculate.CalculateProcentageOfTotalProduction("0006", "2022");
        // Assert
        Assert.Equal(expectedProduction, result);
    }
}