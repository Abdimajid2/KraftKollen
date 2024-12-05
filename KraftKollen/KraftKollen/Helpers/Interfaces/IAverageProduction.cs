namespace KraftKollen.Helpers;

public interface IAverageProduction
{
    Task<double> ProductionForYears(string regionId, List<string> years);
}