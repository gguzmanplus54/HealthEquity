using HealthEquity.Models;

namespace HealthEquity.Services
{
   public interface ICarService
{
    Car GetCarById(int id);
    IEnumerable<Car> GetAllCars();
    void AddCar(Car car);
    void UpdateCar(Car car);
    void RemoveCar(Car car);
}
}