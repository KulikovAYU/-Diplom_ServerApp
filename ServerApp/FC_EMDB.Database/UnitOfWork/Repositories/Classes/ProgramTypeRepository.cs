using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Database.UnitOfWork
{
  public  class ProgramTypeRepository : Repository<ProgramType>, IProgramTypeRepository
    {
        public ProgramTypeRepository(DataBaseFcContext context) : base(context)
        {
        }
    }
}
