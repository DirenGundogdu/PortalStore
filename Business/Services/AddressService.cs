using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;

namespace Business.Services;

public class AddressService : Service<Address>, IAddressService
{
    public AddressService(IRepository<Address> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}
