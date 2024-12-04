using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class CalculateProductionDifference : ICalculateProductionDifference
    {
        public double CalculateDifference(double productionYearOne, double productionYearTwo) // Beräknar skillnaden i elproduktionen utifrån valda år
        {
            return productionYearTwo - productionYearOne;
        }
    }
}
