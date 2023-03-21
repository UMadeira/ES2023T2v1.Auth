using Auth.Data.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Item
    {
        public Repository( IUnitOfWork unitOfWork, DbContext context ) 
        { 
            UnitOfWork = unitOfWork;
            Context = context;
        }

        private IUnitOfWork UnitOfWork { get; set; }

        private DbContext   Context { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Create( params object?[]? args )
        {
            return UnitOfWork.Factory.Create<TEntity>( args );
        }

        public void Insert(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            Context.Remove( item );
        }

    }
}
