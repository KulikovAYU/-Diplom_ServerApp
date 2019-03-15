using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class PreRegistrationRepository : Repository<PreRegistration>, IPreregistrationRepository
    {
        public PreRegistrationRepository(DataBaseFcContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с предварительными записями клиентов на тренировку
    }
}
