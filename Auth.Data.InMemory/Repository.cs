using Auth.Data.Classes;

namespace Auth.Data.InMemory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Item
    {
        public Repository( UnitOfWork unitOfWork ) 
        { 
            UnitOfWork = unitOfWork;
        }

        private UnitOfWork UnitOfWork { get; set; }

        public IEnumerable<TEntity> GetAll() => UnitOfWork.Items.OfType<TEntity>();


        public TEntity Create( params object?[]? args )
        {
            return UnitOfWork.Factory.Create<TEntity>( args );
        }

        public void Insert(TEntity item)
        {
            if ( UnitOfWork.Items.Contains(item) ) return;
            UnitOfWork.Items.Add(item);
        }

        public void Update(TEntity item)
        {
        }

        public void Delete(TEntity item)
        {
            if (! UnitOfWork.Items.Contains(item)) return;
            UnitOfWork.Items.Remove(item);
        }
    }
}
