using System.Threading.Tasks;
using KraftKollen.Repository.Models;

namespace KraftKollen.Repository;

public interface IApiService
{
    Task<WindPowerProductionDTO> GetWindPowerProduction(string municipality, string year);
   
    
}