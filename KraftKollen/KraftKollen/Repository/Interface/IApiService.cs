using System.Threading.Tasks;
using KraftKollen.Models;
using KraftKollen.Repository.Models;

namespace KraftKollen.Repository;

public interface IApiService
{
    Task<WindPowerProduction> GetWindPowerProduction(string municipality, string year);
   
    
}