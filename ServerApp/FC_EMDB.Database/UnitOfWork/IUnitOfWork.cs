﻿using System;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork.Interfaces;

namespace FC_EMDB.Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IClientRepository Clients { get; }

        IAbonementStatusRepository AbonementStatuses { get; }

        IAbonementTypeRepository AbonementTypes { get; }

        ITrainingClientRepository TrainingClients { get; }

        IReplacedTrainingRepository ReplacedTrainings { get; }

        ITrainingDataRepository TrainingDatas { get; }
        
        ITrainingRepository Trainings { get; }

        IGymRepository Gyms { get; }

        ICoachTrainingRepository CoachesTrainings { get; }

        IEmployeeRepository Employees { get; }

        IRoleRepository Roles { get; }

        ITrainingLevelRepository TrainingLevels { get; }

        IProgramTypeRepository ProgramTypes { get; }

        IFcmInfoRepository FcmInfos { get; }

        IClientsFcmInfoRepository ClientsFcmInfos { get; }
        int Complete();

        Task<int> CompleteAsync();

    }
}
