using Xunit;
using KraftKollen.Models;
using System.Collections.Generic;
using Xunit.Abstractions;
using KraftKollen.Helpers;

namespace KraftKollen.Tests
{
    public class TopProductionTests : IClassFixture<TopProductionFixture>
    {
        private readonly TopProductionFixture _fixture;

        public TopProductionTests(TopProductionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetTopProductionYears_WithSufficientData_ReturnsTopThreeYears() // Returns top three years with production data
        {
            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(_fixture.SampleProductionData);

            // Assert
            Assert.Equal(3, result.Count);  // Checks that there are 3 results in the list
            Assert.Equal(2021, result[0].Year); // Checks that the first year in the list is 2021
            Assert.Equal(600.0, result[0].Production);  // Checks that the production for the first year is 600
            Assert.Equal(2022, result[1].Year);
            Assert.Equal(550.0, result[1].Production);
            Assert.Equal(2020, result[2].Year);
            Assert.Equal(500.0, result[2].Production);
        }

        [Fact]
        public void GetTopProductionYears_WithInsufficientData_ReturnsEmptyList() // Returns empty list if there is not enough data (less than 3 years with production data)
        {
            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(_fixture.InsufficientProductionData); 

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetTopProductionYears_WithEmptyData_ReturnsEmptyList()  // Returns empty list if there is no data
     
        {
            // Arrange
            var emptyData = new List<WindPowerProduction>();

            // Act
            var result = _fixture.ProductionAnalyzer.GetTopProductionYears(emptyData);

            // Assert
            Assert.Empty(result);
        }
    }
}
