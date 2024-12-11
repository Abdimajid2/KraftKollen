using KraftKollen.Repository;

namespace KraftKollen.Helpers;

public class AverageProduction : IAverageProduction
{
    private readonly IApiService _apiService;

    public AverageProduction(IApiService apiService)
    {
        _apiService = apiService;
    }
 
    /// <summary>
    /// Calculates the average production for certain region over years 
    /// </summary>
    /// <param name="regionId"></param>
    /// <param name="years"></param>
    /// <returns></returns>
    public async Task<double> ProductionForYears(string regionId, List<string> years)
    {
        var productionValue = new List<double>();
        foreach (var year in years)
        {
            var data = await _apiService.GetWindPowerProduction(regionId, year);
            if (data?.Value != null)
            {
                productionValue.Add((double)data.Value);
            }
        }
        return productionValue.Any() ? productionValue.Average() : 0;
    }
}