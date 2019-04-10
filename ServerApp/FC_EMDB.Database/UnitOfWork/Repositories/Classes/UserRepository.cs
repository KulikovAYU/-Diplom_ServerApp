using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        //TODO: Разместите объявления методов для работы с пользователями
    }
}
