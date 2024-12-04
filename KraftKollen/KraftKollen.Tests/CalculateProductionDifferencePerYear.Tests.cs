using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KraftKollen.Helpers;
using KraftKollen;
using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Tests
{
    public class CalculateProductionDifferencePerYear
    {
        public class CalculateProductionDifferencePerTwoYear : IClassFixture<CalculateProductionDifferenceFixture>
        {
            private readonly ICalculateProductionDifference _calculator;
            private readonly double _production2019;
            private readonly double _production2020;
            private readonly double _production2021;
            private readonly double _production2022;

            public CalculateProductionDifferencePerTwoYear(CalculateProductionDifferenceFixture fixture)
            {
                _calculator = fixture.Calculator;
                _production2019 = fixture.Production2019;
                _production2020 = fixture.Production2020;
                _production2021 = fixture.Production2021;
                _production2022 = fixture.Production2022;               
            }

            [Fact]
            public void CalculateProductionFor2019And2020ReturnsCorrectDifference()
            {
                // Arrange
                double expectedDifference = _production2020 - _production2019;

                // Act
                double actualDifference = _calculator.CalculateDifference(_production2019, _production2020);

                // Assert
                Assert.Equal(expectedDifference, actualDifference);
            }

            [Fact]
            public void CalculateProductionFor2020And2021ReturnsCorrectDifference()
            {
                // Arrange
                double expectedDifference = _production2021 - _production2020;

                // Act
                double actualDifference = _calculator.CalculateDifference(_production2020, _production2021);

                // Assert
                Assert.Equal(expectedDifference, actualDifference);
            }

            [Fact]
            public void CalculateProductionFor2021And2022ReturnsCorrectDifference()
            {
                // Arrange
                double expectedDifference = _production2022 - _production2021;

                // Act
                double actualDifference = _calculator.CalculateDifference(_production2021, _production2022);

                // Assert
                Assert.Equal(expectedDifference, actualDifference);
            }
        }
    }
}
