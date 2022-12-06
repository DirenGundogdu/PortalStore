using Core.Entities;

namespace Core.IServices;

public interface IBasketService : IService<Basket>
{
    List<Basket> GetCustomerBasket(int customerId);
}
