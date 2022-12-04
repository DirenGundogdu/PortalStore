using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
