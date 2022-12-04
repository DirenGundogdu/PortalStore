using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services;

public class CustomerService : Service<Customer>, ICustomerService
{
    public CustomerService(IRepository<Customer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
