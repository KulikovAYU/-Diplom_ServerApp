using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    class AbonementRepository : Repository<Abonement>, IAbonementRepository
    {
        public AbonementRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {

        }

        //TODO: Разместите действия для работы с абонементами
    }
}
