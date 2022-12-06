using Core.Entities;
using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IRepository<Basket> _repository;
        public BasketService(IRepository<Basket> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository=repository;
        }

        public List<Basket> GetCustomerBasket(int customerId)
        {
            return _repository.Where(x => x.CustomerId == customerId).Include(x => x.Product).Include(x => x.Customer).ToList();
        }
    }
}
