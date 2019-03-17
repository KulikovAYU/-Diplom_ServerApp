using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
   public class TrainingDataTrainingRepository : Repository<TrainingDataTraining>, ITrainingDataTrainingRepository
    {
        public TrainingDataTrainingRepository(DataBaseFcContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с расписанями
    }
}
