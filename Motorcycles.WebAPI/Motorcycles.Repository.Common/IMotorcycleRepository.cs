using Motorcycles.Model;
using System.Collections.Generic;

namespace Motorcycles.Repository.Common
{
    public interface IMotorcycleRepository
    {
        Task AddMotorcycleAsync(Motorcycle motorcycle);
        Task UpdateMotorcycleAsync(Motorcycle motorcycle);
        Task DeleteMotorcycleAsync(int id);
        Task<Motorcycle> GetMotorcycleAsync(int id);
        Task<List<Motorcycle>> GetMotorcyclesByUserNameAsync(string firstName, string lastName);
    }
}