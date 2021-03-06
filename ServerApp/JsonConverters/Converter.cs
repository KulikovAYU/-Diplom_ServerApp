﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities;
using FC_EMDB.Entities.Entities;
using JsonConverters.JSONEntities;

namespace JsonConverters
{
    public static class TrainingJSONconverter
    {
        public static async Task<IEnumerable<JSONTraining>> ToJSONAsync(this IEnumerable<Training> trainings, IUnitOfWork uiOfWork)
        {
            ICollection< JSONTraining > JsonTrainings = new List<JSONTraining>();
            foreach (var training in trainings)
            {

               var tr = await training.ToJSONAsync(uiOfWork);
                if (tr != null)
                {
                    JsonTrainings.Add(tr);
                }
            }
            //упорядочим по времени
             var orderedTrainings = JsonTrainings.OrderBy(p => p.StartTime);
            return orderedTrainings;
        }


        public static async Task<JSONTraining>  ToJSONAsync(this Training training, IUnitOfWork uiOfWork)
        {
            if (training.TrainingDataId != null)
            {
                TrainingData data = await uiOfWork.TrainingDatas.GetAsync((int)training.TrainingDataId);
                if (data.IsNull())
                    return null;

                ProgramType pt = await uiOfWork.ProgramTypes.GetAsync(data.ProgramTypeId);
                if (pt.IsNull())
                    return null;

                TrainingLevel tl = await uiOfWork.TrainingLevels.GetAsync(data.LevelId);
                if (tl.IsNull())
                    return null;

                Gym gym = await uiOfWork.Gyms.GetAsync(training.GymId);
                if (gym.IsNull())
                    return null;

                CoachTraining ct =
                    await uiOfWork.CoachesTrainings.FindAsync(coachTraining => coachTraining.TrainingId == training.Id);
                if (ct.IsNull())
                    return null;

                Employee empl = await uiOfWork.Employees.GetAsync(ct.CoachId);
                if (empl.IsNull())
                    return null;

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

                    CoachId = empl.Id,
                    CoachName = empl.Name,
                    CoachFamily = empl.Family,
                    LevelName = tl.Name,

                };

                //Если это платная тренировка
                if (data is PayTraining payTraining)
                {
                    tr.PlacesCount = payTraining.PlacesCount;
                    tr.BusyPlacesCount = training.BusyPlacesCount;
                    //tr.FreePlacesCount = payTraining.FreePlacesCount;
                }
                return tr;
            }
           
            return null;
        }

        public static JSONCoach ToJSON(this Employee coach)
        {
            JSONCoach jsonCoach = new JSONCoach()
            {
                Id = coach.Id,
                Name = coach.Name,
                Family = coach.Family,
                Desc = coach.Desc
            };
            return jsonCoach;
        }

        public static async Task<JSONClient> ToJSONAsync(this Client client, IUnitOfWork uiOfWork)
        {

            var status = (await uiOfWork.AbonementStatuses.GetAsync(client.AbonementStatusId)).Name;


            JSONClient jsonClient = new JSONClient()
            {
                Id = client.Id,
                Name = client.Name,
                Family = client.Family,
                LastName = client.LastName,
                DateOfBirdth = client.DateOfBirdth,
                AbonementNumber = client.AbonementNumber,
                AbonementActionTime = client.AbonementActionTime,
                AbonementType = (await uiOfWork.AbonementTypes.GetAsync(client.AbonementTypeId)).Name,
                AbonementStatus = (await uiOfWork.AbonementStatuses.GetAsync(client.AbonementStatusId)).Name,
                IsAсtive = String.Equals(status, "Активен"),
                IsFreeze = String.Equals(status, "Заморожен"),
                AbonementEndTime = client.AbonementDateOfActivate.AddDays(client.AbonementActionTime.Day).AddHours(client.AbonementActionTime.Hour).AddMonths(client.AbonementActionTime.Month)

            };
            return jsonClient;
        }

    }
}
