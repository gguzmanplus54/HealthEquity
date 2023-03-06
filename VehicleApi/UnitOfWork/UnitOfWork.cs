using HealthEquity.Models;
using HealthEquity.Repositories;
using HealthEquity.Uow;

namespace HealthEquity.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly List<Car> _cars;
        private ICarRepository _carRepository;

        public UnitOfWork(List<Car> cars)
        {
            _cars = cars;
        }

        public ICarRepository Cars
        {
            get
            {
                if (_carRepository == null)
                {
                    _carRepository = new CarRepository(_cars);
                }
                return _carRepository;
            }
        }
      
    }
}