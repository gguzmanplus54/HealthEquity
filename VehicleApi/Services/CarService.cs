
using HealthEquity.Models;
using HealthEquity.Uow;

namespace HealthEquity.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Car GetCarById(int id)
        {
            return _unitOfWork.Cars.GetById(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _unitOfWork.Cars.GetAll();
        }

        public void AddCar(Car car)
        {
            _unitOfWork.Cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            _unitOfWork.Cars.Update(car);
        }

        public void RemoveCar(Car car)
        {
            _unitOfWork.Cars.Remove(car);
        }
    }
}