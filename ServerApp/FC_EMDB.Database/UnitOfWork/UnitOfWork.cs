using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.Interfaces;
using FC_EMDB.Database.UnitOfWork.Interfaces;
using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FC_EMDB.Database.UnitOfWork
{
    public class UnitOfWork : Microsoft.EntityFrameworkCore.DbContext,IUnitOfWork
    {
        private  readonly DataBaseFcContext m_context;

        public UnitOfWork(DbContextOptions<DataBaseFcContext> options) : base(options)
        {
            //создаем контекст БД
            m_context = new DataBaseFcContext(options);

             //инциализация репозиториев
            Abonements = new AbonementRepository(m_context);
            Coaches = new CoachRepository(m_context);
            Trainings = new TrainingRepository(m_context);
            TrainingsAbonements = new TrainingsAbonementsRepository(m_context);
            Preregistrations = new PreRegistrationRepository(m_context);
            CoachesTrainings = new CoachTrainingRepository(m_context);
        }

        //Экземпляры репозиториев
        /// <summary>
        /// Репозиторий для работы с абонементами
        /// </summary>
        public IAbonementRepository Abonements { get;private set; }
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
    }
}
