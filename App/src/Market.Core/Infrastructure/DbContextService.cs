using System;
using Market.Core.Database;

namespace Market.Core.Infrastructure
{
    public abstract class DbContextService : IDisposable
    {
        //private static readonly Logger<> DbContextLogger = LogManager.GetCurrentClassLogger();

        protected DbContextService(DataContext db)//, IEventBus eventBus)
        {
            Db = db;
            //EventBus = eventBus;
        }

        //protected IEventBus EventBus { get; set; }
        protected DataContext Db { get; set; }

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