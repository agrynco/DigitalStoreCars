using Domain;

namespace DAL.EF
{
    public class BaseApplicationRepository<TEntity> :
        BaseRepository<CarsDbContext, TEntity, long>
        where TEntity : Entity
    {
        public BaseApplicationRepository(CarsDbContext dbContext) : base(dbContext)
        {
        }
    }
}