using KraftKollen.Helpers.Interfaces;

namespace KraftKollen.Helpers
{
    public class CalculateResultsInGwhAndTwhFixture // Fixture  - handles instances used in multiple tests.
    {
        public ICalculateResultsInGwhAndTwh CalculateGwhAndTwhService { get; private set; } // Private property should be readable outside the class but not changed.

        public CalculateResultsInGwhAndTwhFixture() // Creates an instance of CalculateResultsInGwhAndTwh.
        {
            CalculateGwhAndTwhService = new CalculateResultsInGwhAndTwh();
        }
    }   
}