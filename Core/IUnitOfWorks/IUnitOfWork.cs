namespace Core.IUnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    int Commit();
}
