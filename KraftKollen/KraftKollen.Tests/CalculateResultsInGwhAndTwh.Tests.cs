using KraftKollen.Helpers;
using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Tests
{
    public class CalculateResultsInGwhAndTwh : IClassFixture<CalculateResultsInGwhAndTwhFixture>
    {
        public readonly ICalculateResultsInGwhAndTwh _calculateResultsInGwhAndTwh; // Is used to call the method to be tested.

        public CalculateResultsInGwhAndTwh(CalculateResultsInGwhAndTwhFixture fixture) 
        {
            _calculateResultsInGwhAndTwh = fixture.CalculateGwhAndTwhService; // The constructor receives an instance of the fixture class that contains, shared state (CalculateGwhAndTwhService).
        }

        [Theory]      
        [InlineData(1000, 1.0, 0.0)] // Theory 1 = 1000 Mwh | 1.0 Gwh (1000/1000) | 0.0 Twh (1000/1000000).
        [InlineData(1000000, 1000.0, 1.0)]
        [InlineData(1500123, 1500.12, 1.5)]
        [InlineData(1234567, 1234.57, 1.23)]
        public void CalculateResultsInGwhTwH_ShouldReturnCorrectResult(double value, double expectedGwh, double expectedTwh) // Value in Mwh, Gwh and Twh.
        {
            // Act - Execute the test CalculateResultsInGwhTwH method in _calculateResultsInGwhAndTwh with the input value.

            var result = _calculateResultsInGwhAndTwh.CalculateResultsInGwhTwH(value);

            //Assert - compare the result with the expected values.

            Assert.Equal(expectedGwh, result.Gwh);
            Assert.Equal(expectedTwh, result.Twh);
           
        }
    }
}