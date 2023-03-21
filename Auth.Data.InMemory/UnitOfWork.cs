using Auth.Data.Classes;

namespace Auth.Data.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        public IList<Item> Items { get; set; } = new List<Item>();

        public Factory Factory { get; set; } = new Factory();

        public void Begin()
        {
        }

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public void SaveChanges()
        {
        }

        public void Dispose()
        {
        }

        private IDictionary<Type,dynamic> Repositories { get; } = new Dictionary<Type,dynamic>();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Item
        {
            if ( Repositories.ContainsKey( typeof(TEntity) ) )
                return Repositories[typeof(TEntity) ] as IRepository<TEntity>;

            var repository = new Repository<TEntity>( this );
            Repositories.Add( typeof(TEntity), repository );

            return repository;
        }


    }
}