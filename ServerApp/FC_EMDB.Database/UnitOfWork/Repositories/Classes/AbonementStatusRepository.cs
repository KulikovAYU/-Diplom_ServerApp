using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
  public  class AbonementStatusRepository : Repository<AbonementStatus>, IAbonementStatusRepository
    {
        public AbonementStatusRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
            //TODO: Разместите объявления методов для работы со статусами абонемента
        }
    }
}
