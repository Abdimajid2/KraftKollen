using KraftKollen.Models;

namespace KraftKollen.Tests;

using Moq;
using KraftKollen.Repository;
using KraftKollen.Helpers;

public class AverageProduction_Test
{
    [Theory]
    [InlineData("region1", new string[] { "2020", "2021" }, new double[] { 1000, 2000 }, 1500)] 
    [InlineData("region2", new string[] { "2020", "2021" }, new double[] { 0, 0 }, 0)]  
    [InlineData("region3", new string[] { "2020", "2021", "2022" }, new double[] { 1500, 0, 2500 }, 2000)] 
    public async Task ProductionForYears(string regionId, string[] years, double[]? productionValue,
        double expectedValue)
    {
        // Arrange
        var mockapi = new Mock<IApiService>();
        for (int i = 0; i < years.Length; i++)
        {
            //if i is bigger than 0 return the value otherwise return null
            double? value = productionValue[i] > 0 ? productionValue[i] : null;

            mockapi.Setup(api => api.GetWindPowerProduction(regionId, years[i]))
                .ReturnsAsync(new WindPowerProduction { Value = value });
        }
        var averageProduction = new AverageProduction(mockapi.Object);
        // Act
        var result = await averageProduction.ProductionForYears(regionId, years.ToList());
        // Assert
        Assert.Equal(expectedValue, result);
    }
}