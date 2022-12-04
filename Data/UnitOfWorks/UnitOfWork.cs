using Core.IUnitOfWorks;

namespace Data.UnitOfWorks
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    int commit = _context.SaveChanges();
                    tran.Commit();
                    return commit;
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                    return 0;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
