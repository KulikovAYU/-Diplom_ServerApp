using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
  public  class AbonementStatusRepository : Repository<AbonementStatus>, IAbonementStatusRepository
    {
        public AbonementStatusRepository(DataBaseFcContext context) : base(context)
        {
            //TODO: Разместите объявления методов для работы со статусами абонемента
        }
    }
}
