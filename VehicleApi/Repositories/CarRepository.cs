using HealthEquity.Models;


namespace HealthEquity.Repositories
{
public class CarRepository : ICarRepository
{
    private readonly List<Car> _cars;

    public CarRepository(List<Car> cars)
    {
        _cars = cars;
    }

    public Car GetById(int id)
    {
        return _cars.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Car> GetAll()
    {
        return _cars;
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        var existingCar = GetById(car.Id);
        if (existingCar != null)
        {
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Doors = car.Doors;
            existingCar.Color = car.Color;
            existingCar.Price = car.Price;
        }
    }

    public void Remove(Car car)
    {
        _cars.Remove(car);
    }
}
}