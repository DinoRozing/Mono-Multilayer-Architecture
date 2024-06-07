using Motorcycles.Service.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Motorcycles.Service.Common
{
    public interface IMotorcycleService
    {
        Task AddMotorcycleAsync(MotorcycleDTO motorcycleDto);
        Task UpdateMotorcycleAsync(MotorcycleDTO motorcycleDto);
        Task DeleteMotorcycleAsync(int id);
        Task<MotorcycleDTO> GetMotorcycleAsync(int id);
        Task<List<MotorcycleDTO>> GetMotorcyclesByUserNameAsync(string firstName, string lastName);
    }
}
