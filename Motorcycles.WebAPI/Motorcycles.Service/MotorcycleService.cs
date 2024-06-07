using AutoMapper;
using Motorcycles.Model;
using Motorcycles.Repository.Common;
using Motorcycles.Service.Common;
using Motorcycles.Service.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Motorcycles.Service
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IMapper _mapper;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository, IMapper mapper)
        {
            _motorcycleRepository = motorcycleRepository;
            _mapper = mapper;
        }

        public async Task AddMotorcycleAsync(MotorcycleDTO motorcycleDto)
        {
            var motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
            await _motorcycleRepository.AddMotorcycleAsync(motorcycle);
        }

        public async Task UpdateMotorcycleAsync(MotorcycleDTO motorcycleDto)
        {
            var motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
            await _motorcycleRepository.UpdateMotorcycleAsync(motorcycle);
        }

        public async Task DeleteMotorcycleAsync(int id)
        {
            await _motorcycleRepository.DeleteMotorcycleAsync(id);
        }

        public async Task<MotorcycleDTO> GetMotorcycleAsync(int id)
        {
            var motorcycle = await _motorcycleRepository.GetMotorcycleAsync(id);
            return _mapper.Map<MotorcycleDTO>(motorcycle);
        }

        public async Task<List<MotorcycleDTO>> GetMotorcyclesByUserNameAsync(string firstName, string lastName)
        {
            var motorcycles = await _motorcycleRepository.GetMotorcyclesByUserNameAsync(firstName, lastName);
            return _mapper.Map<List<MotorcycleDTO>>(motorcycles);
        }
    }
}
