using IFSPStore.Domain.Base;
using IFSPStore.Repository.Context;
using Mysqlx.Crud;
using System.Data.Entity;
using System.Reflection.Metadata.Ecma335;

namespace IFSPStore.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<int>

    {
        protected IFSPStoreContext _mySqlContext;

        public BaseRepository(IFSPStoreContext myContext)
        {
            _mySqlContext = myContext;
        }
        public void AttachObjetc(object obj)
        {
            _mySqlContext.Attach(obj);
        }

        public void CleanChangeTracker()
        {
            _mySqlContext.ChangeTracker.Clear();
        }

        public void Update(TEntity obj)
        {
            _mySqlContext.SaveChanges();
        }
        public void Delete(object id)
        {
            _mySqlContext.Set<TEntity>().Remove(Select(id));
            _mySqlContext.SaveChanges();
        }

        public void Insert(TEntity obj)
        {
            _mySqlContext.Set<TEntity>().Add(obj);
            _mySqlContext.SaveChanges();
        }

        public IList<TEntity> Select(IList<string>? includes = null)
        {
            var dbContext = _mySqlContext.Set<TEntity>().AsQueryable();
            if ((includes != null))
            {
                foreach (var include in includes) {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList();
        }

        public TEntity? Select(object id, IList<string>? includes = null)
        {
            var dbContext = _mySqlContext.Set<TEntity>().AsQueryable();
            if ((includes != null))
            {
                foreach (var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList().Find(x => x.Id == (int)id);
        }
    }
}
