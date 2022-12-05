using Core.Entities;
using Core.IRepositories;

namespace Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{

    public ProductRepository(AppDbContext context) : base(context)
    {
    }

}
