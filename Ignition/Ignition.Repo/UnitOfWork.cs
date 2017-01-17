using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using Ignition.Repo.Dao;
using Ignition.Repo.Model;

namespace Ignition.Repo
{
    public class UnitOfWork
    {
        private static IgniteDataContext _databaseContext;
        private GenericRepository<User> _userRepository;

        static UnitOfWork()
        {
            _databaseContext=new IgniteDataContext();
        }

        public UnitOfWork()
        {
            // enable this line to see all sql statements in the console!
            //_databaseContext.Database.Log = Console.Write;
        }


        public GenericRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_databaseContext)); }
        }

        public void Dispose()
        {
            if (_databaseContext != null)
            {
                _databaseContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public DbConnection Connection
        {
            get { return _databaseContext.Database.Connection; }
        }

        public IgniteDataContext Context
        {
            get { return _databaseContext; }
            set { _databaseContext = value; }
        }

        public void Commit()
        {
            _databaseContext.SaveChanges();
        }

        public void ResetData()
        {
            var objectContext = ((IObjectContextAdapter)_databaseContext).ObjectContext;
            var objectStateEntries = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged);

            foreach (var objectStateEntry in objectStateEntries.Where(x => x.Entity != null))
            {
                objectContext.Detach(objectStateEntry.Entity);
            }
        }

#if DEBUG

        public string GetContextStats(Type type = null)
        {
            var entries = _databaseContext.ChangeTracker.Entries().Where(e => (type == null || e.Entity.GetType() == type)).ToList();
            return string.Format("Unchanged: {0,3}  Created: {1,3}  Modified: {2,3}  Deleted: {3,3}",
                entries.Count(e => e.State == EntityState.Unchanged),
                entries.Count(e => e.State == EntityState.Added),
                entries.Count(e => e.State == EntityState.Modified),
                entries.Count(e => e.State == EntityState.Deleted)
            );
        }

        public string GetContextTypes()
        {
            var stats = new StringBuilder();
            var entries = _databaseContext.ChangeTracker.Entries();
            foreach (var type in entries.GroupBy(g => g.Entity.GetType()).Select(g => g.Key))
                stats.AppendLine(string.Format("{0,-40} - {1}", ObjectContext.GetObjectType(type).Name, GetContextStats(type)));
            stats.AppendLine(new string('-', 98));
            stats.AppendLine(string.Format("{0,-40} - {1}", string.Empty, GetContextStats()));
            return stats.ToString();
        }
#endif
    }
}