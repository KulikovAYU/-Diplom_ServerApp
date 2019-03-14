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
            Abonements = serviceProvider.GetRequiredService<IAbonementRepository>();
            Coaches = serviceProvider.GetRequiredService<ICoachRepository>();
            Trainings = serviceProvider.GetRequiredService<ITrainingRepository>();
            TrainingsAbonements = serviceProvider.GetRequiredService<ITrainingAbonementRepository>();
            Preregistrations = serviceProvider.GetRequiredService<IPreregistrationRepository>();
            CoachesTrainings = serviceProvider.GetRequiredService<ICoachTrainingRepository>();
        }

        //Экземпляры репозиториев
        /// <summary>
        /// Репозиторий для работы с абонементами
        /// </summary>
        public IAbonementRepository Abonements { get; }
        /// <summary>
        /// Репозиторий для работы с тренерами
        /// </summary>
        public ICoachRepository Coaches { get; }
        /// <summary>
        /// Репозиторий для работы с тренировками
        /// </summary>
        public ITrainingRepository Trainings { get; }
        /// <summary>
        /// Репозиторий для работы с посещениями клиентов тренировок
        /// </summary>
        public ITrainingAbonementRepository TrainingsAbonements { get; }
        /// <summary>
        /// Репозиторий для работы с предварительными записями клиентов
        /// </summary>
        public IPreregistrationRepository Preregistrations { get; }
        /// <summary>
        /// Репозиторий для работы с сущностью "занятие - тренер"
        /// </summary>
        public ICoachTrainingRepository CoachesTrainings { get; }

        /// <summary>
        /// Сохраняет изменения
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return m_context.SaveChanges();
        }
        public void Dispose()
        {
            m_context.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await m_context.SaveChangesAsync();
        }

    }
}
