using System.Linq.Expressions;

namespace Core.IServices;

public interface IService<T> where T : class
{
    #region Get
    T GetById(int id);
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    bool Any(Expression<Func<T, bool>> expression);
    #endregion

    #region Add
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    #endregion

    #region Update
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    #endregion

    #region Delete
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    #endregion
}
