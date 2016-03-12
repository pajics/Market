using System;
using Market.Core.Database;

namespace Market.Core.Infrastructure
{
    public abstract class DbContextQuery : IDisposable
    {
        //private static readonly Logger DbContextLogger = LogManager.GetCurrentClassLogger();

        protected DataContext Db { get; set; }

        protected DbContextQuery(DataContext db)
        {
            Db = db;
        }

        public void Dispose()
        {
            if (Db == null)
            {
                return;
            }

            try
            {
                Db.Dispose();
            }
            catch (Exception ex)
            {
                //DbContextLogger.Error("Could not dispose data context", ex);
            }
        }
    }
}