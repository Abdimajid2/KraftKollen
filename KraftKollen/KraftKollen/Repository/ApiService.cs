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
        
        return await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipality}/year/{year}");
  
    }
    
   
    public async Task<WindPowerProductionDTO> GetWindPowerProduction(List<string> municipalities, string year)
    {
        
        return await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipalities}/year/{year}");
  
    }
 
        
    
}

 