using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
   public class TrainingDataTrainingRepository : Repository<TrainingDataTraining>, ITrainingDataTrainingRepository
    {
        public TrainingDataTrainingRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с расписанями
    }
}
