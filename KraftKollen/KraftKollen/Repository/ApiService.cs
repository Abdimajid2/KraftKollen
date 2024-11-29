using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using KraftKollen.Models;
using KraftKollen.Repository.Models;

namespace KraftKollen.Repository;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ApiService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }
    
    public async Task<WindPowerProduction> GetWindPowerProduction(string municipality, string year)
    {
        var data = await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipality}/year/{year}");

        if (data == null)
        {
            throw new Exception("The API returned null. Check the endpoint or request parameters.");
        }

        var result = _mapper.Map<WindPowerProduction>(data);
        return result;
  
    }

    public async Task<WindPowerProductionDTO> GetTotalPowerProduction(string municipality, string year)
    {
        return await _httpClient.GetFromJsonAsync<WindPowerProductionDTO>($"http://api.kolada.se/v2/data/kpi/N45904/municipality/{municipality}/year/{year}");

    }
    
     
        
    
}

 