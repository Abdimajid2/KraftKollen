namespace KraftKollen.Helpers;

public interface ICalculateProcentage
{
    Task<double?> CalculateProcentageOfTotalProduction(string regionId, string year);
}