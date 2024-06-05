using Motorcycles.Service.Common;
using Motorcycles.Model;
using System.Collections.Generic;

namespace Motorcycles.Service
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public void AddMotorcycle(Motorcycle motorcycle)
        {
            _motorcycleRepository.AddMotorcycle(motorcycle);
        }

        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            _motorcycleRepository.UpdateMotorcycle(motorcycle);
        }

        public void DeleteMotorcycle(int id)
        {
            _motorcycleRepository.DeleteMotorcycle(id);
        }

        public Motorcycle GetMotorcycle(int id)
        {
            return _motorcycleRepository.GetMotorcycle(id);
        }

        public List<Motorcycle> GetMotorcyclesByUserName(string firstName, string lastName)
        {
            return _motorcycleRepository.GetMotorcyclesByUserName(firstName, lastName);
        }
    }
}
