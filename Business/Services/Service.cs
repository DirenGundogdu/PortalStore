using Core.IRepositories;
using Core.IServices;
using Core.IUnitOfWorks;
using System.Linq.Expressions;

namespace Business.Services;

public class Service<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    #region Add
    public void Add(T entity)
    {
        _repository.Add(entity);
        _unitOfWork.Commit();
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _repository.AddRange(entities);
        _unitOfWork.Commit();
    }
    #endregion


    #region Get
    public bool Any(Expression<Func<T, bool>> expression)
    {
      return _repository.Any(expression);

    }

    public IQueryable<T> GetAll()
    {
       return _repository.GetAll();
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _repository.Where(expression);
    }
    #endregion

    #region Delete
    public void Remove(T entity)
    {
        _repository.Remove(entity);
        _unitOfWork.Commit();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _repository.RemoveRange(entities);
        _unitOfWork.Commit();
    }
    #endregion

    #region Update
    public void Update(T entity)
    {
        _repository.Update(entity);
        _unitOfWork.Commit();
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
       _repository.UpdateRange(entities);
        _unitOfWork.Commit();
    }
    #endregion
    
}
