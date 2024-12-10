using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class CalculateResultsInGwhAndTwh : ICalculateResultsInGwhAndTwh
    {  
        public GwhTwhResult CalculateResultsInGwhTwH(double value) //Method for calculating Gwh and Twh
        {
            double gwh = Math.Round(value / 1000, 2);
            double twh = Math.Round(value / 1_000_000, 2); // Underscores indicates that this is a million. Rounds the result to two decimals

            return new GwhTwhResult
            {
                Gwh = gwh,
                Twh = twh
            };          
        }
    }  
}