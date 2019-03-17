using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
   public class TrainingDataRepository : Repository<TrainingData>, ITrainingDataRepository
    {
        public TrainingDataRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с данними о тренировке
    }
}
