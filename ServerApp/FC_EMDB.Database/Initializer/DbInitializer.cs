using System;
using FC_EMDB.Database.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FC_EMDB.Database.Initializer
{
    public class DbInitializer
    {
        public static void Seed(IUnitOfWork context)
        {
            // UnitOfWork.IUnitOfWork context = IoC.ApplicationDbContext; //1 способ - получить из IoC

           

            //https://www.youtube.com/watch?v=oDz7ku6fRkg

            //если нет абонементов
            if (!context.Abonements.GetAll().Any())
            {

            }

            //если нет тренировок
            if (!context.Trainings.GetAll().Any())
            {

            }

            //если нет посещений
            if (!context.TrainingsAbonements.GetAll().Any())
            {

            }

            //если нет предварительных записей
            if (!context.Preregistrations.GetAll().Any())
            {

            }

            //если нет тренировок-тренеров
            if (!context.CoachesTrainings.GetAll().Any())
            {

            }

            //если нет тренировок-тренеров
            if (!context.Coaches.GetAll().Any())
            {

            }

                //сохраняем изменения
                ((UnitOfWork.UnitOfWork)context).Complete();

        }
    }
}
