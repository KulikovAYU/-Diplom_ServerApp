using System;
using System.Threading.Tasks;
using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FC_EMDB.Database.UnitOfWork
{
    public class UnitOfWork : Microsoft.EntityFrameworkCore.DbContext,IUnitOfWork
    {
        private  readonly DataBaseFcContext m_context;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            //получаем контекст БД
            m_context = (DataBaseFcContext) serviceProvider.GetService(typeof(DataBaseFcContext));

            //инциализация репозиториев
            Clients = serviceProvider.GetRequiredService<IClientRepository>();
            AbonementStatuses = serviceProvider.GetRequiredService<IAbonementStatusRepository>();
            AbonementTypes = serviceProvider.GetRequiredService<IAbonementTypeRepository>();
            TrainingClients = serviceProvider.GetRequiredService<ITrainingClientRepository>();
            TrainingDataTrainings = serviceProvider.GetRequiredService<ITrainingDataTrainingRepository>();
            TrainingDatas = serviceProvider.GetRequiredService<ITrainingDataRepository>();
            Trainings = serviceProvider.GetRequiredService<ITrainingRepository>();
            Gyms = serviceProvider.GetRequiredService<IGymRepository>();
            CoachesTrainings = serviceProvider.GetRequiredService<ICoachTrainingRepository>();
            Employees = serviceProvider.GetRequiredService<IEmployeeRepository>();
            Roles = serviceProvider.GetRequiredService<IRoleRepository>();
            ReplacedTrainings = serviceProvider.GetRequiredService<IReplacedTrainingRepository>();
            //
        }

        //Экземпляры репозиториев

        /// <summary>
        /// Репозиторий для работы с клиентами
        /// </summary>
        public IClientRepository Clients { get; }
        /// <summary>
        /// Репозиторий для работы со статусами абонемента
        /// </summary>
        public IAbonementStatusRepository AbonementStatuses { get; }
        /// <summary>
        /// Репозиторий для работы с видами абонементами
        /// </summary>
        public IAbonementTypeRepository AbonementTypes { get; }
        /// <summary>
        /// Репозиторий для работы с посещениями
        /// </summary>
        public ITrainingClientRepository TrainingClients { get; }
        /// <summary>
        /// Репозиторий для работы с расписанием
        /// </summary>
        public ITrainingDataTrainingRepository TrainingDataTrainings { get; }
        /// <summary>
        /// Репозиторий для работы с данными о тренировке
        /// </summary>
        public ITrainingDataRepository TrainingDatas { get; }
        /// <summary>
        /// Репозиторий для работы с тренировками в расписании
        /// </summary>
        public ITrainingRepository Trainings { get; }
        /// <summary>
        /// Репозиторий для работы с залами
        /// </summary>
        public IGymRepository Gyms { get; }
        /// <summary>
        /// Репозиторий для работы с сущностью "занятие - тренер"
        /// </summary>
        public ICoachTrainingRepository CoachesTrainings { get; }
        /// <summary>
        /// Репозиторий для работы с работниками
        /// </summary>
        public IEmployeeRepository Employees { get; }
        /// <summary>
        /// Репозиторий для работы с ролью пользователя системы
        /// </summary>
        public IRoleRepository Roles { get; }
        /// <summary>
        /// Репозиторий для работы с замененными тренировками
        /// </summary>
        public IReplacedTrainingRepository ReplacedTrainings { get; }


        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return m_context.SaveChanges();
        }
        public override void Dispose()
        {
            m_context.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await m_context.SaveChangesAsync();
        }
    }
}
