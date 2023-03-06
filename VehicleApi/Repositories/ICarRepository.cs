using HealthEquity.Models;

namespace HealthEquity.Repositories
{
    public interface ICarRepository
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Remove(Car car);
    }
}