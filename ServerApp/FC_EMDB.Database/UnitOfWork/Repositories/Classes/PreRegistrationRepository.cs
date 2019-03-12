using FC_EMDB.Database.Interfaces;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    class PreRegistrationRepository : Repository<PreRegistration>, IPreregistrationRepository
    {
        public PreRegistrationRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: Разместите действия для работы с предварительными записями клиентов на тренировку
    }
}
