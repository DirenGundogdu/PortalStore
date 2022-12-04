using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services;

public class OrderItemService : Service<OrderItem>, IOrderItemService
{
    public OrderItemService(IRepository<OrderItem> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
