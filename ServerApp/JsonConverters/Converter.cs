using System.Collections.Generic;
using System.Linq;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities;
using FC_EMDB.Entities.Entities;
using JsonConverters.JSONEntities;

namespace JsonConverters
{
    public static class TrainingJSONconverter
    {
        public static IEnumerable<JSONTraining> ToJSON(this IEnumerable<Training> trainings, IUnitOfWork uiOfWork)
        {
            ICollection< JSONTraining > JsonTrainings = new List<JSONTraining>();
            foreach (var training in trainings)
            {
                TrainingData data = uiOfWork.TrainingDatas.Get(training.Id);
                if (data.IsNull())
                    continue;

                ProgramType pt = uiOfWork.ProgramTypes.Get(data.ProgramTypeId);
                if (pt.IsNull())
                    continue;

                TrainingLevel tl = uiOfWork.TrainingLevels.Get(data.LevelId);
                if (tl.IsNull())
                    continue;

                Gym gym = uiOfWork.Gyms.Get(training.GymId);
                if (gym.IsNull())
                    continue;

                CoachTraining ct =
                    uiOfWork.CoachesTrainings.Find(coachTraining => coachTraining.TrainingId == training.Id);
                if (ct.IsNull())
                    continue;

                Employee empl = uiOfWork.Employees.Get(ct.CoachId);
                if (empl.IsNull())
                    continue;

                JSONTraining tr = new JSONTraining
                {
                    Id = training.Id,
                    StartTime = training.StartTime,
                    EndTime = training.EndTime,
                    IsFinished = training.IsFinished,
                    GymName = gym.Name,

                    Description = data.TrainingDescription,
                    IsMustPay = data.IsMustPay,
                    TrainingName = data.TrainingName,
                    IsNewTraining = data.IsNewTraining,
                    Ispopular = data.Ispopular,

                    ProgramType = pt.Name,

                    CoachId   = empl.Id,
                    CoachName = empl.Name,
                    CoachFamily = empl.Family,
                    LevelName = tl.Name,

                };

                //Если это платная тренировка
                if (data is PayTraining payTraining)
                {
                    tr.PlacesCount = payTraining.PlacesCount;
                    tr.BusyPlacesCount = payTraining.BusyPlacesCount;
                    tr.FreePlacesCount = payTraining.FreePlacesCount;
                }

                //JsonTrainings.
                JsonTrainings.Add(tr);
            
            }
            //упорядочим по времени
            JsonTrainings.OrderBy(p => p.StartTime);

            return JsonTrainings;
        }
    }
}
