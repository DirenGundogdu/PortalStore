using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
