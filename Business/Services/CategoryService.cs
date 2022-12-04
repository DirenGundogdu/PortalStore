using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
