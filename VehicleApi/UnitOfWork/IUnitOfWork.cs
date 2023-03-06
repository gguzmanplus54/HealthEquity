using HealthEquity.Repositories;

namespace HealthEquity.Uow
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        
    }
}