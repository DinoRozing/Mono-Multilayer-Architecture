using Motorcycles.Service.Common;
using Motorcycles.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Motorcycles.Repository.Common;

namespace Motorcycles.Service
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task AddMotorcycleAsync(Motorcycle motorcycle)
        {
            await _motorcycleRepository.AddMotorcycleAsync(motorcycle);
        }

        public async Task UpdateMotorcycleAsync(Motorcycle motorcycle)
        {
            await _motorcycleRepository.UpdateMotorcycleAsync(motorcycle);
        }

        public async Task DeleteMotorcycleAsync(int id)
        {
            await _motorcycleRepository.DeleteMotorcycleAsync(id);
        }

        public async Task<Motorcycle> GetMotorcycleAsync(int id)
        {
            return await _motorcycleRepository.GetMotorcycleAsync(id);
        }

        public async Task<List<Motorcycle>> GetMotorcyclesByUserNameAsync(string firstName, string lastName)
        {
            return await _motorcycleRepository.GetMotorcyclesByUserNameAsync(firstName, lastName);
        }
    }
}