using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using KraftKollen.Repository.Models;

namespace KraftKollen.Repository;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<WindPowerProductionDTO> GetWindPowerProduction(string municipality, string year)
    {
        var result = await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipality}/year/{year}");
        return result;
  
    }

    public async Task<WindPowerProductionDTO> GetTotalPowerProduction(string municipality, string year)
    {
        return await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipality}/year/{year}");

    }
    
     
        
    
}

 