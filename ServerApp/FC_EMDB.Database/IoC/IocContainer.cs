using FC_EMDB.Database.DbContext;

using Microsoft.Extensions.DependencyInjection;

namespace FC_EMDB.Database
{

    public static class IoC
    {
        /// <summary>
        /// Получаем из IocContainer -> DataBaseFcContext
        /// </summary>
         public static DataBaseFcContext ApplicationDbContext => IocContainer.Provider.GetService<DataBaseFcContext>();

       //   public static IUnitOfWork ApplicationDbContext => IocContainer.Provider.GetService<UnitOfWork.UnitOfWork>();
    }

    /// <summary>
    /// Контейнер сохраняет ServiceProvider для доступа из любого места в приложении
    /// </summary>
    public static class IocContainer
    {
        public static ServiceProvider Provider { get; set; }
    }
}
