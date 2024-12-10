namespace KraftKollen.Helpers.Interfaces
{  
    public interface ICalculateResultsInGwhAndTwh
    {
        GwhTwhResult CalculateResultsInGwhTwH(double value);    // Takes an input, value of type double (energy value in MWh).
                                                                // Returns an object of type GwhTwhResult (the calculated results in GWh and TWh).
    }
}