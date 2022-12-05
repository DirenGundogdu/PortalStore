using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public List<Product> GetProductsWithCategory()
        {
            var result = _repository.GetAll().Include(x => x.Category).ToList();
            return result;
        }
    }
}
