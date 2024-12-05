using KraftKollen.Repository;

namespace KraftKollen.Helpers;

public class CalculateForecastForProduction
{
    private readonly IApiService _apiService;

    public CalculateForecastForProduction(IApiService apiService)
    {
        _apiService = apiService;
    }

    // public async Task<double> CalculateReggression(string regionId, string year)
    // {
    //     
    // }
}