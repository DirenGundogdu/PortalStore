using Core.Entities;

namespace Core.IServices;

public interface IProductService : IService<Product>
{
    List<Product> GetProductsWithCategory();
}
