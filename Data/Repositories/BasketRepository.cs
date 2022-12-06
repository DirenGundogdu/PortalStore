using Core.Entities;
using Core.IRepositories;

namespace Data.Repositories;

public class BasketRepository : Repository<Basket>, IBasketRepository
{
    public BasketRepository(AppDbContext context) : base(context)
    {
    }
}
