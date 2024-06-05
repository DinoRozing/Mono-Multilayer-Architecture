using Motorcycles.Model;

namespace Motorcycles.Repository.Common
{
    public interface IMotorcycleRepository
    {
        void AddMotorcycle(Motorcycle motorcycle);
        void UpdateMotorcycle(Motorcycle motorcycle);
        void DeleteMotorcycle(int id);
        Motorcycle GetMotorcycle(int id);
        List<Motorcycle> GetMotorcyclesByUserName(string firstName, string lastName);
    }
}