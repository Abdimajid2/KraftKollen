using KraftKollen.Helpers.Interfaces;


namespace KraftKollen.Helpers
{
    public class CalculateProductionDifferenceFixture 
    {
        public ICalculateProductionDifference Calculator { get; private set; }

        public double Production2019 { get; private set; }
        public double Production2020 { get; private set; }
        public double Production2021 { get; private set; }
        public double Production2022 { get; private set; }

        public CalculateProductionDifferenceFixture()
        {

            Calculator = new CalculateProductionDifference();
            Production2019 = 19234852; // Värde  år 2019
            Production2020 = 26306655; // Värde år 2020
            Production2021 = 26520886; // Värde år 2021
            Production2022 = 32483482; // Värde år 2022
        }         
    }
}
