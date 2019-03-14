using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(DataBaseFcContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с инструкторами
    }
}
