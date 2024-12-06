using KraftKollen.Models;
using System.Globalization;


namespace KraftKollen.Helpers
{
    public class TrendCalculatorFixture
    {
        public TrendCalculator TrendCalculator { get; set; }
        public List<WindPowerProduction> IncreasingTrendData { get; set; }
        public List<WindPowerProduction> DecreasingTrendData { get; set; }
        public List<WindPowerProduction> UnchangedTrendData { get; set; }
        public List<WindPowerProduction> InsufficientTrendData { get; set; }


        public TrendCalculatorFixture()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sv-SE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sv-SE");

            TrendCalculator = new TrendCalculator();
            IncreasingTrendData = new List<WindPowerProduction>
            {
                new () { Period = 2023, Value = 100 },
                new () { Period = 2024, Value = 200 }
            };
            DecreasingTrendData = new List<WindPowerProduction>
            {
                new () { Period = 2023, Value = 200 },
                new () { Period = 2024, Value = 100 }
            };
            UnchangedTrendData = new List<WindPowerProduction>
            {
                new () { Period = 2023, Value = 100 },
                new () { Period = 2024, Value = 100 }
            };
            InsufficientTrendData = new List<WindPowerProduction>
            {
                new () { Period = 2023, Value = 100 }
            };
        }
    }
}
