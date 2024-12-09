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
        public void CalculateTrend_WithLessThanTwoDataPoints_ReturnsError()
        {

            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.InsufficientTrendData);

           _output.WriteLine(CultureInfo.DefaultThreadCurrentCulture.DisplayName);
            // Assert
            Assert.Equal("Kan ej hitta trend.", result);
        }

        [Fact]
        public void CalculateTrend_WithIncreasingValues_ReturnUpwardTrend()
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.IncreasingTrendData);

            // Assert
            Assert.Equal("Trenden stiger!", result);
        }

        [Fact]
        public void CalculateTrend_WithDecreasingValues_ReturnDownwardTrend()
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.DecreasingTrendData);

            // Assert
            Assert.Equal("Trenden sjunker!", result);
        }

        [Fact]
        public void CalculateTrend_WithUnchangedValues_ReturnsNoChangeTrend()
        {


            // Act
            var result = _fixture.TrendCalculator.CalculateTrend(_fixture.UnchangedTrendData);

            // Assert
            Assert.Equal("Trenden orubbad!", result);
        }
    }
}
