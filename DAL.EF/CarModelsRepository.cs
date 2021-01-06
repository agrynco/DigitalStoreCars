using DAL.Abstract;
using Domain;

namespace DAL.EF
{
    public class CarModelsRepository : BaseApplicationRepository<CarModel>, ICarModelsRepository
    {
        public CarModelsRepository(CarsDbContext dbContext) : base(dbContext)
        {
        }
    }
}