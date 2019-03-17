using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
    public class RoleRepository : Repository<Role>, IRoleRepository 
    {
        public RoleRepository(DataBaseFcContext context) : base(context)
        {
        }

        //TODO: Разместите объявления методов для работы с ролью
    }
}
