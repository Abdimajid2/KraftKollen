using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class YearComparisonIndicatorFixture : IDisposable
    {
        public IYearComparisonIndicator YearComparisonIndicator { get; }

        public YearComparisonIndicatorFixture()
        {
            YearComparisonIndicator = new YearComparisonIndicator(); 
        }

        public void Dispose()
        {
            // Clean up resources if necessary
        }
    }

}
