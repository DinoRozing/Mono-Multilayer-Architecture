using Motorcycles.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Motorcycles.Service.Common
{
    public interface IMotorcycleService
    {
        Task AddMotorcycleAsync(Motorcycle motorcycle);
        Task UpdateMotorcycleAsync(Motorcycle motorcycle);
        Task DeleteMotorcycleAsync(int id);
        Task<Motorcycle> GetMotorcycleAsync(int id);
        Task<List<Motorcycle>> GetMotorcyclesByUserNameAsync(string firstName, string lastName);
    }
}