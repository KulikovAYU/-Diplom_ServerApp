using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
  public  class ProgramTypeRepository : Repository<ProgramType>, IProgramTypeRepository
    {
        public ProgramTypeRepository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }
    }
}
