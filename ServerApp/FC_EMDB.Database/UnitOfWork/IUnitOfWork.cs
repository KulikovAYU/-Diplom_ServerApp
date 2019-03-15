using System;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork.Interfaces;

namespace FC_EMDB.Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAbonementRepository Abonements { get; }

        ICoachRepository Coaches { get; }

        ITrainingRepository Trainings { get; }

        ITrainingAbonementRepository TrainingsAbonements { get; }

        IPreregistrationRepository Preregistrations { get; }

        ICoachTrainingRepository CoachesTrainings { get; }

        IAbonementStatusRepository AbonementStatuses { get; }

        IAbonementTypeRepository AbonementTypes { get; }

        IDescriptionRepository Descriptions { get; }

        int Complete();

        Task<int> CompleteAsync();

    }
}
