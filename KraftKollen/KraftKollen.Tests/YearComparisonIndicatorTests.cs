using KraftKollen.Helpers;
using KraftKollen.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftKollen.Tests
{
    public class YearComparisonIndicatorTests(YearComparisonIndicatorFixture fixture) : IClassFixture<YearComparisonIndicatorFixture>
    {
        private readonly IYearComparisonIndicator _yearComparisonIndicator = fixture.YearComparisonIndicator;

        [Fact]
        public void GetCorrectValueRight()
        {
            // Arrange
            var firstYear = 1; 
            var secondYear = 2;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("Right", result);
        }

        [Fact]
        public void GetCorrectValueLeft()
        {
            // Arrange
            var firstYear = 2;
            var secondYear = 1;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("Left", result);
        }

        [Fact]
        public void GetCorrectValueEquals()
        {
            // Arrange
            var firstYear = 1;
            var secondYear = 1;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("Equal", result);
        }

        [Fact]
        public void FirstYearIsNull()
        {
            // Arrange
            double? firstYear = null;
            var secondYear = 1;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("firstYear is null", result);
        }

        [Fact]
        public void SecondYearIsNull()
        {
            // Arrange
            var firstYear = 1;
            double? secondYear = null;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("secondYear is null", result);
        }

        [Fact]
        public void HandlesNegativeNumbers()
        {
            // Is a test like this necessary when the expected outcome is never a negative number?

            // Arrange
            var firstYear = -1;
            double? secondYear = -2;

            // Act
            var result = _yearComparisonIndicator.GetYearComparisonIndicator(firstYear, secondYear);
            // Assert
            Assert.Equal("Left", result);
        }
    }
}
