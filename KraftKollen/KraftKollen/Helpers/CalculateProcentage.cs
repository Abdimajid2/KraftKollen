using KraftKollen.Repository;

namespace KraftKollen.Helpers;

public class CalculateProcentage : ICalculateProcentage
{
    private readonly IApiService _apiService;

    public CalculateProcentage(IApiService apiService)
    {
        _apiService = apiService;
        
    }

    public async Task<double?> CalculateProcentageOfTotalProduction(string regionId, string year)
    {
        var totalProduction = await _apiService.GetTotalPowerProduction(regionId, year);

        var windpowerProduction = await _apiService.GetWindPowerProduction(regionId, year);
        double? thePercentage = (windpowerProduction.Value / totalProduction.Value) * 100;
        return thePercentage;
    }
}