using System.Linq.Expressions;

namespace Core.IServices;

public interface IService<T> where T : class
{
    #region Get
    Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    #endregion

    #region Add
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    #endregion

    #region Update
    void Update(T entity);
    #endregion

    #region Delete
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    #endregion
}
