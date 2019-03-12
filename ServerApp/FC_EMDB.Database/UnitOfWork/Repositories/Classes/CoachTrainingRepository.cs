using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class CoachTrainingRepository : Repository<CoachTraining>, ICoachTrainingRepository
    {
        public CoachTrainingRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с сущностью "тренировка - тренер"
    }
}
