using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class YearComparisonIndicator : IYearComparisonIndicator
    {
        public string GetYearComparisonIndicator(double? firstYear, double? secondYear)
        {
            if (firstYear == null)
                return "firstYear is null";

            if (secondYear == null)
                return "secondYear is null";

            if (firstYear > secondYear)
            {
                return "Left";
            }
            else if (firstYear < secondYear)
            {
                return "Right";
            }
            else
            {
                return "Equal";
            }
        }
    }
}
