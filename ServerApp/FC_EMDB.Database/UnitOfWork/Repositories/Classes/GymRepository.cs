using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class GymRepository : Repository<Gym>, IGymRepository
    {
        public GymRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с залами
    }
}
