using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    /// <summary>
    /// Сущность "посещенные тренировки"
    /// </summary>
    public class VisitedTrainingClientRepository : Repository<VisitedTrainingClient>,IVisitedTrainingClientRepository
    {
        public VisitedTrainingClientRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: действия над списком посещений
    }
}
