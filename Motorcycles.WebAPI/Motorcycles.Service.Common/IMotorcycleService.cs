using Motorcycles.Model;

namespace Motorcycles.Service.Common
{
    public interface IMotorcycleService
    {
        void AddMotorcycle(Motorcycle motorcycle);
        void UpdateMotorcycle(Motorcycle motorcycle);
        void DeleteMotorcycle(int id);
        Motorcycle GetMotorcycle(int id);
        List<Motorcycle> GetMotorcyclesByUserName(string firstName, string lastName);
    }
}