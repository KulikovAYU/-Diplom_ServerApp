using System;
using System.Collections.Generic;
using System.Net.Mime;
using FC_EMDB.Database.Tools;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace FC_EMDB.Database.Initializer
{
    public class DbInitializer
    {
        public static void Seed(IUnitOfWork context)
        {
            // UnitOfWork.IUnitOfWork context = IoC.ApplicationDbContext; //1 способ - получить из IoC
      
            //если нет статусов абонемента
            if (!context.AbonementStatuses.GetAll().Any())
            {
               var  sss = context.AbonementStatuses;
                context.AbonementStatuses.AddRange(new List<AbonementStatus>()
                {
                    new AbonementStatus {Name = "Активен"},
                    new AbonementStatus {Name = "Не активен"},
                    new AbonementStatus {Name = "Заморожен"}
                });

                context.Complete(); //сохраняем изменения
            }

            //если нет типа абонемента
            if (!context.AbonementTypes.GetAll().Any())
            {
                context.AbonementTypes.AddRange(new List<AbonementType>()
                {
                    new AbonementType {Name = "Утренний"},
                    new AbonementType {Name = "Вечер"},
                    new AbonementType(){Name = "Карта полного дня"}
                });
                context.Complete(); //сохраняем изменения
            }

            //если нет данных об уровне тренировок
            if (!context.TrainingLevels.GetAll().Any())
            {
                context.TrainingLevels.AddRange(new List<TrainingLevel>()
                {
                    new TrainingLevel() {Name = "Для всех уровней подготовки"},
                    new TrainingLevel() {Name = "Низкая интенсивность"}
                });
                context.Complete(); //сохраняем изменения
            }

            //если нет данных об типе программы
            if (!context.ProgramTypes.GetAll().Any())
            {
                context.ProgramTypes.AddRange(new List<ProgramType>()
                {
                    new ProgramType() {Name = "Специальные программы"},
                    new ProgramType() {Name = "Силовой и функциональный тренинг"},
                    new ProgramType() {Name = "Mind&Body (Мягкий фитнес)"}
                });
                context.Complete(); //сохраняем изменения
            }

            //если нет данных о залах, создадим
            if (!context.Gyms.GetAll().Any())
            {
                context.Gyms.AddRange(new List<Gym>()
                {
                    new Gym() {Name =  "Большой зал"},
                    new Gym() {Name =  "Тренажерный зал"},
                    new Gym() {Name =  "Зал персональных занятий"},
                });
                context.Complete(); //сохраняем изменения
            }


            //если нет данных о тренировке
                if (!context.TrainingDatas.GetAll().Any())
            {
                context.TrainingDatas.AddRange(new List<TrainingData>()
                {
                    new TrainingData()
                    {
                        TrainingName = "Hatha Yoga", TrainingDescription =
                            "Занятие, на котором помимо асан и пранаямы делается акцент на "
                            + "концентрацию внимания и медитацию. Урок рекомендован для всех уровней подготовки",
                        Level = context.TrainingLevels.Get(2),
                        ProgramType = context.ProgramTypes.Get(2),
                        IsNewTraining = true
                    },
                    new PayTraining()
                    {
                        TrainingName = "TRX", TrainingDescription =
                            "TRX - тренировка мышц всего тела с помощью уникального оборудования - " +
                            "TRX-петель. Это тренировка, которая позволяет не только развивать все мышечные группы, " +
                            "укреплять связки и сухожилия, но и развивать гибкость, ловкость, выносливость и многое " +
                            "другое. Данная тренировка имеет еще одно важное достоинство - эффективное развитие мышц так " +
                            "называемого кора(мышц-стабилизаторов). Упражнения подходят для всех возрастных групп, " +
                            "для мужчин и женщин, для лиц с отклонениями в состоянии здоровья, так как в этой тренировке " +
                            "нет никакой осевой (вертикальной) нагрузки на позвоночник",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(1),
                        PlacesCount = 10, 
                    },
                    new TrainingData()
                    {
                        TrainingName = "New Body", TrainingDescription =
                            "NEW BODY (55 мин) («Новое тело») - силовой урок, направленный на тренировку всех " +
                            "групп мышц. Специально подобранные комплексы упражнений помогут скорректировать проблемные зоны, " +
                            "независимо от того, каким телосложением вы обладаете. Урок рекомендован как для среднего так и для " +
                            "продвинутого уровня подготовки",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "ABS+Stretch", TrainingDescription =
                            "Урок, направленный на развитие гибкости, с использованием специальных упражнений на растягивание. " +
                            "Увеличивает подвижность суставов, эластичность связок, дает общее расслабление и релаксацию.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Pilates", TrainingDescription =
                            "Урок направлен на укрепление мышц-стабилизаторов, упражнгения пилатес " +
                            "способствуют снятию напряжению с позвоночника, восстановлению эластичности " +
                            "связочного аппарата и мышц. Урок рекомендован для всех уровней подготовки",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(3),
                        Ispopular = true
                    }

                });
                context.Complete(); //сохраняем изменения
            }

            //если нет тренировки в расписании
            if (!context.Trainings.GetAll().Any())
            {
                context.Trainings.AddRange(new List<Training>()
                {
                    new Training()
                    {
                        StartTime = new DateTime(2019, 2, 8, 7, 30, 0),
                        EndTime =   new DateTime(2019, 2, 8, 8, 30, 0),
                        Gym = context.Gyms.Get(1)
                    },
                    new Training()
                    {
                        StartTime = new DateTime(2019, 2, 8, 8, 30, 0),
                        EndTime = new DateTime(2019, 2, 8, 9, 30, 0),
                        Gym = context.Gyms.Get(2)
                    },
                    new Training()
                    {
                        StartTime = new DateTime(2019, 2, 8, 10, 00, 0),
                        EndTime = new DateTime(2019, 2, 8, 10, 30, 0),
                        Gym = context.Gyms.Get(1)
                    },
                    new Training()
                    {
                        StartTime = new DateTime(2019, 2, 8, 16, 00, 0),
                        EndTime = new DateTime(2019, 2, 8, 16, 30, 00),
                        Gym = context.Gyms.Get(1)
                    },
                    new Training()
                    {
                        StartTime = new DateTime(2019, 2, 8, 17, 30, 00),
                        EndTime = new DateTime(2019, 2, 8, 18, 30, 00),
                        Gym = context.Gyms.Get(1)
                    }

                });
                context.Complete(); //сохраняем изменения
            }

            //если нет таблицы TrainingDataTrainings
            if (!context.TrainingDataTrainings.GetAll().Any())
            {
                context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(1).Id, TrainingId = context.Trainings.Get(1).Id });
                context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(2).Id, TrainingId = context.Trainings.Get(2).Id });
                context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(3).Id, TrainingId = context.Trainings.Get(3).Id });
                //создаем замененную тернировку
                context.Trainings.Get(1).ReplcedTrainings.Add(new ReplcedTraining() { TrainingDataId = context.TrainingDatas.Get(4).Id, TrainingId = context.Trainings.Get(4).Id });
                context.Complete(); //сохраняем изменения
            }

            //Создадим клиента
            if (!context.Clients.GetAll().Any())
            {
                context.Clients.AddRange(new List<Client>()
                {
                    new Client(){Family = "Куликов", Name = "Антон",LastName = "Юрьевич",
                        DateOfBirdth = DateTime.Parse("24.03.2000"),
                        Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath()),
                        AbonementStatus = context.AbonementStatuses.Get(1),
                        AbonementType =  context.AbonementTypes.Get(1),
                        AbonementDateOfRegistration = DateTime.Now,
                        AbonementNumber = AbonementGenerator.CreateNumberSubscription(context),
                        PasportData = $"2409 N460870 ОУФМС РОССИИ {DateTime.Parse("04.05.2012")}",
                        PasswordHash = "2705",
                        AbonementStatusId =  context.AbonementStatuses.Get(1).Id,
                        AbonementActionTime =  DateTime.Parse("30.05.2019"),
                        AbonementTypeId = context.AbonementTypes.Get(2).Id,
                    }
                });
            }

            //добавим тренировки клиенту по пред записи
            if (!context.TrainingClients.GetAll().Any())
            {
                context.Clients.Get(1).TrainingClients.Add(new TrainingClient(){}); //остановился
            }



            //если нет описания
            //if (!context.Descriptions.GetAll().Any())
            //{
            //    context.Descriptions.AddRange(
            //        new List<Description>()
            //        {
            //            new Description { Desc = "Занятие, на котором помимо асан и пранаямы делается акцент на " +
            //                                        "концентрацию внимания и медитацию. Урок рекомендован для всех уровней подготовки"},

                //            new Description { Desc =  "TRX - тренировка мышц всего тела с помощью уникального оборудования - " +
                //                                       "TRX-петель. Это тренировка, которая позволяет не только развивать все мышечные группы, " +
                //                                       "укреплять связки и сухожилия, но и развивать гибкость, ловкость, выносливость и многое " +
                //                                       "другое. Данная тренировка имеет еще одно важное достоинство - эффективное развитие мышц так " +
                //                                       "называемого кора(мышц-стабилизаторов). Упражнения подходят для всех возрастных групп, " +
                //                                       "для мужчин и женщин, для лиц с отклонениями в состоянии здоровья, так как в этой тренировке " +
                //                                       "нет никакой осевой (вертикальной) нагрузки на позвоночник" },

                //            new Description { Desc =  "NEW BODY (55 мин) («Новое тело») - силовой урок, направленный на тренировку всех " +
                //                                       "групп мышц. Специально подобранные комплексы упражнений помогут скорректировать проблемные зоны, " +
                //                                       "независимо от того, каким телосложением вы обладаете. Урок рекомендован как для среднего так и для " +
                //                                       "продвинутого уровня подготовки"},

                //            new Description { Desc = "Урок, направленный на развитие гибкости, с использованием специальных упражнений на растягивание. " +
                //                                       "Увеличивает подвижность суставов, эластичность связок, дает общее расслабление и релаксацию."},

                //            new Description { Desc = "Урок направлен на укрепление мышц-стабилизаторов, упражнгения пилатес " +
                //                                       "способствуют снятию напряжению с позвоночника, восстановлению эластичности " +
                //                                       "связочного аппарата и мышц. Урок рекомендован для всех уровней подготовки"}
                //        }
                //        );

                //    context.Complete(); //сохраняем изменения
                //}



                ////если нет тренировок
                //if (!context.Trainings.GetAll().Any())
                //{
                //    context.Trainings.AddRange(new List<Training>()
                //    {
                //        new Training
                //        {
                //            TrainingName = "Hatha Yoga", StartTime = new DateTime(2019, 2, 8, 7, 30, 0),
                //            EndTime = new DateTime(2019, 2, 8, 8, 30, 0), DescriptionId = context.Descriptions.Get(0).Id
                //        }
                //    });//Остановился
                //}


                ////https://www.youtube.com/watch?v=oDz7ku6fRkg

                ////если нет абонементов
                //if (!context.Abonements.GetAll().Any())
                //{
                //    context.Abonements.AddRange(new List<Abonement>()
                //    {
                //        //Создадим таблицу статусов


                //        new Abonement()
                //        {
                //            Number=1234,DateOfRegistration = DateTime.Now,ActionTime =  new DateTime(DateTime.Now.Year,DateTime.Now.Month + 2,DateTime.Now.Day),
                //            AbonementStatus =  context.AbonementStatuses.Find(abon=>abon.Name == "Активен"),
                //            AbonementType = context.AbonementTypes.Find(type=>type.Name == "Утренний"),



                //        }
                //    });
                //    int n = 1;
                //    n = 10;
                //}



                ////если нет посещений
                //if (!context.TrainingsAbonements.GetAll().Any())
                //{

                //}

                ////если нет предварительных записей
                //if (!context.Preregistrations.GetAll().Any())
                //{

                //}

                ////если нет тренировок-тренеров
                //if (!context.CoachesTrainings.GetAll().Any())
                //{

                //}

                ////если нет тренировок-тренеров
                //if (!context.Coaches.GetAll().Any())
                //{

                //}



        }
    }
}
