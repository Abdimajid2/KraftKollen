using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;

namespace KraftKollen.Helpers
{
    public class TopProductionFixture
    {
        public ITopProduction ProductionAnalyzer { get; private set; }
        public List<WindPowerProduction> SampleProductionData { get; private set; }
        public List<WindPowerProduction> InsufficientProductionData { get; private set; }

        public TopProductionFixture()
        {
            ProductionAnalyzer = new TopProduction();

            SampleProductionData = new List<WindPowerProduction>
            {
                new() { Period = 2020, Value = 500 },
                new() { Period = 2021, Value = 600 },
                new() { Period = 2022, Value = 550 },
                new() { Period = 2019, Value = 400 },
                new() { Period = 2018, Value = 300 }
            };

            InsufficientProductionData = new List<WindPowerProduction>
            {
                new() { Period = 2020, Value = 500 }
            };
        }
    }
}
