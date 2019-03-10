using Microsoft.EntityFrameworkCore;

namespace FC_EMDB.Database.DbContext
{
    public class DataBaseFcContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataBaseFcContext(DbContextOptions<DataBaseFcContext> options) : base(options)
        {
            //Гарантирует, что база данных для контекста не существует. Если он не существует, никаких действий не предпринимается. Если он существует, то база данных удаляется.
            Database.EnsureDeleted();
        }
    }
}
