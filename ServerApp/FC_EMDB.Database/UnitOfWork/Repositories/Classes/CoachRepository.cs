using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с инструкторами
    }
}
