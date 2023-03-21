using Auth.Data.Classes;

namespace Auth.Data
{
    public interface IRepository<TEntity> where TEntity : Item
    {

        IEnumerable<TEntity> GetAll();

        TEntity Create();

        void Insert( TEntity item );
        void Update( TEntity item );
        void Delete( TEntity item );
    }
}
