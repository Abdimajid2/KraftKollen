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
            private readonly ICalculateProductionDifference _calculator; // _calculator is used in the class to call methods defined in ICalculateProductionDifference.
            private readonly double _production2019; // Production value for a specific year.
            private readonly double _production2020;
            private readonly double _production2021;
            private readonly double _production2022;

            public CalculateProductionDifferencePerTwoYear(CalculateProductionDifferenceFixture fixture)
            {
                _calculator = fixture.Calculator; // fixture.Calculator is a property of CalculateProductionDifferenceFixture that returns an instance of a class that implements ICalculateProductionDifference.
                _production2019 = fixture.Production2019; // Production values ​​for different years.
                _production2020 = fixture.Production2020;
                _production2021 = fixture.Production2021;
                _production2022 = fixture.Production2022;               
            }

            [Fact] // Individual test case.
            public void CalculateProductionFor2019And2020ReturnsCorrectDifference()
            {
                // Arrange - expected difference between production values ​​for 2020 and 2019.
                double expectedDifference = _production2020 - _production2019;

                // Act - call CalculateDifference-method and compare the actual result (actualDifference) with the expected value.
                double actualDifference = _calculator.CalculateDifference(_production2019, _production2020);

                // Assert - is the expected difference in the production correct between the two years.
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

        public class CalculateProductionDifferenceWithTheoryData 
        {
            private readonly ICalculateProductionDifference _calculator;

            public CalculateProductionDifferenceWithTheoryData () // Instance of CalculateProductionDifference is created, which implements the logic for calculating differences between two production years.
            {
                _calculator = new CalculateProductionDifference();
            }

            [Theory] // Different situations (calculate the difference between two year output values).
            [InlineData(1000, 1000, 0)] // Production values ​​are the same for both years: 1000, 1000, result is 0.
            [InlineData(500, -500, -1000)] // Production values ​​are negative and positive, return negatve. 
            [InlineData(0, 0, 0)] // Verify that resultate is 0 if production value is 0 in both years.
           
            public void CalculateDifference_ShouldReturnCorrectResult(double yearOne, double yearTwo, double expectedDifference)
            {
                // Act - compares the expected value (expectedDifference) with the actual result. 
                var result = _calculator.CalculateDifference(yearOne, yearTwo);

                // Assert - is the expected difference in the production correct between the two years.
                Assert.Equal(expectedDifference, result);
            }            
        }
    }
}