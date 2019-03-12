using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    class TrainingRepository : Repository<Training>, ITrainingRepository
    {
        public TrainingRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с тренировками
    }
}
