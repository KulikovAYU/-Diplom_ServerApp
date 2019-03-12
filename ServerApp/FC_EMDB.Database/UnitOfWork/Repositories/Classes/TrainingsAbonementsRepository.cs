using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    class TrainingsAbonementsRepository : Repository<TrainingAbonement>, ITrainingAbonementRepository
    {
        public TrainingsAbonementsRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
        //TODO: Разместите действия для работы с посещениями
    }
}
