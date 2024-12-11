using KraftKollen.Helpers;
using KraftKollen.Models;
using Xunit;
using System.Collections.Generic;
using Xunit.Abstractions;
using System.Globalization;


namespace KraftKollen.Tests
{
    public class TrendCalculatorTests : IClassFixture<TrendCalculatorFixture>
    {
        private readonly TrendCalculatorFixture _fixture;
        private readonly ITestOutputHelper _output;

        public TrendCalculatorTests(TrendCalculatorFixture fixture, ITestOutputHelper output)
        {

            // Arrange 
            _fixture = fixture;
            this._output = output;
        }

        [Fact]
        public void CalculateTrend_WithLessThanTwoDataPoints_ReturnsError()  // Testcase that checks that the method returns an error message if there are less than 2 data points
        {

            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.InsufficientTrendData);

           _output.WriteLine(CultureInfo.DefaultThreadCurrentCulture.DisplayName);
            // Assert
            Assert.Equal("Kan ej hitta trend.", result);
        }

        [Fact]
        public void CalculateTrend_WithIncreasingValues_ReturnUpwardTrend()  // Testcase that checks that the method returns "Trenden stiger!" if the values are increasing
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.IncreasingTrendData);

            // Assert
            Assert.Equal("Trenden stiger!", result);
        }

        [Fact]
        public void CalculateTrend_WithDecreasingValues_ReturnDownwardTrend() // Testcase that checks that the method returns "Trenden sjunker!" if the values are decreasing
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.DecreasingTrendData);

            // Assert
            Assert.Equal("Trenden sjunker!", result);
        }

        [Fact]
        public void CalculateTrend_WithUnchangedValues_ReturnsNoChangeTrend() // Testcase that checks that the method returns "Trenden orubbad!" if the values are unchanged
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.UnchangedTrendData);

            // Assert
            Assert.Equal("Trenden orubbad!", result);
        }
    }
}
