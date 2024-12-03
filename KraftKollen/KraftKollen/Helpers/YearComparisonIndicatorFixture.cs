using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class YearComparisonIndicatorFixture : IDisposable
    {
        public IYearComparisonIndicator YearComparisonIndicator { get; }

        public YearComparisonIndicatorFixture()
        {
            // Initialize your dependency here
            YearComparisonIndicator = new YearComparisonIndicator(); // Replace with actual implementation
        }

        public void Dispose()
        {
            // Clean up resources if necessary
        }
    }

}
