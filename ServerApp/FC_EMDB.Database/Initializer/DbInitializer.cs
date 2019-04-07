using System;
using System.Collections.Generic;
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
                context.AbonementStatuses.AddRange(new List<AbonementStatus>()
                {
                    new AbonementStatus {Name = "Активен"},
                    new AbonementStatus {Name = "Не активен"},
                    new AbonementStatus {Name = "Заморожен"}
                });
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
            }

            //если нет данных об уровне тренировок
            if (!context.TrainingLevels.GetAll().Any())
            {
                context.TrainingLevels.AddRange(new List<TrainingLevel>()
                {
                    new TrainingLevel() {Name = "Для всех уровней подготовки"},
                    new TrainingLevel() {Name = "Низкая интенсивность"},
                    new TrainingLevel() {Name = "Высокая интенсивность"}
                });
            }

            //если нет данных об типе программы
            if (!context.ProgramTypes.GetAll().Any())
            {
                context.ProgramTypes.AddRange(new List<ProgramType>()
                {
                    new ProgramType() {Name = "Специальные программы"},
                    new ProgramType() {Name = "Силовой и функциональный тренинг"},
                    new ProgramType() {Name = "Mind&Body (Мягкий фитнес)"},
                    new ProgramType() {Name = "Кардио тренинг"},
                });
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
                        TrainingName = "ABS and Stretch", TrainingDescription =
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
                    },
                    new TrainingData()
                    {
                        TrainingName = "Здоровая спина", TrainingDescription ="Улучшит функционирование внутренних органов " +
                                                                              "и систем организма, укрепит мышечно-связочный аппарат, " +
                                                                              "скорректирует мышечный дисбаланс, будет способствовать развитию" +
                                                                              " гибкости позвоночника и тела в целом, позволит выработать правильную осанку." +
                                                                              " Урок рекомендован для всех уровней подготовки.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(1),
                        Ispopular = true
                    },
                    new TrainingData()
                    {
                        TrainingName = "STEP ABS", TrainingDescription ="Step+ABS – это отличная комбинированная кардио тренировка, " +
                                                                         "сочетающая нагрузку на мышцы брюшного пресса и занятия на степ-платформе.",
                        Level = context.TrainingLevels.Get(3),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "#запускягодицы", TrainingDescription ="Функциональная тренировка, направленная на проработку ягодичных мышц " +
                                                                              "и мышц брюшного пресса. Тренировка состоит из нескольких блоков, с использованием" +
                                                                              " различного оборудования или выполнения упражнений с собственным весом.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Upper Body", TrainingDescription ="(англ. «upper» – верх и «body» – тело) —силовой урок, направленный на проработку мышечных " +
                                                                          "групп верхней части тела: рук, плечевого пояса, спины и брюшного пресса. При этом могут использоваться " +
                                                                          "дополнительные отягощения: гантели, бодибары, степ платформы и т.д Тренировка подходит для любого " +
                                                                          "уровня подготовленности.Главная задача тренировки Upper Body. – это подтянуть живот, сделав мышцы пресса " +
                                                                          "крепкими, а талию узкой, привести мышцы рук в тонус, а также укрепить мышцы груди и спины, что важно для " +
                                                                          "красивой осанки.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Stretch", TrainingDescription ="Урок, направленный на развитие гибкости, с использованием специальных упражнений на растягивание. " +
                                                                        "Увеличивает подвижность суставов, эластичность связок, даёт общее расслабление и релаксацию.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(3)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Callanetics", TrainingDescription ="Уникальная система упражнений, возбуждающая активность глубоко расположенных мышечных групп," +
                                                                            " способствующая оздоровлению организма, снижению веса и уменьшению объемов тела. В статичном режиме " +
                                                                            "тренируются все мышечные группы и связочный аппарат.",
                        Level = context.TrainingLevels.Get(1),
                        ProgramType = context.ProgramTypes.Get(3)
                    },
                    new TrainingData()
                    {
                        TrainingName = "STEP INTERVAL", TrainingDescription ="Step interval - это аэробно-силовой фитнес, сочетающий чередование упражнений " +
                                                                             "(прыжков, приседаний, отжиманий и т.д.) с базовыми шагами на степ-платформе. ",
                        Level = context.TrainingLevels.Get(3),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Soft Mix", TrainingDescription ="Фитнес микс – это синтез различных видов фитнеса, которые комбинированно применяются" +
                                                                        " в условиях одной тренировки либо чередуются от занятия к занятию.",
                        Level = context.TrainingLevels.Get(2),
                        ProgramType = context.ProgramTypes.Get(3)
                    },
                    new TrainingData()
                    {
                        TrainingName = "PUMP", TrainingDescription ="Это целостная система низко-ударной тренировки с использованием облегченной штанги." +
                                                                    " Благодаря PUMP прорабатываются, укрепляются и приводятся в тонус все мышцы тела. " +
                                                                    "Тренировка характеризуется особым агрессивным драйвом и приносит гораздо больше результатов " +
                                                                    "и удовольствия, чем традиционное монотонное поднятие тяжестей. Она подходит как для мужчин, " +
                                                                    "так и для женщин всех возрастов. Для продвинутого уровня подготовки.",
                        Level = context.TrainingLevels.Get(3),
                        ProgramType = context.ProgramTypes.Get(2)
                    },
                    new TrainingData()
                    {
                        TrainingName = "Тabata", TrainingDescription ="Интервальная тренировка, которая включает в себя 10 блоков по 4 минуты. " +
                                                                      "Табата – это сочетание кардио и силовой нагрузок. Тренирует выносливость " +
                                                                      "как ни одна классическая тренировка. В короткий промежуток времени выполняя " +
                                                                      "упражнения происходит максимально быстрое жиросжигание. Упражнения различные по " +
                                                                      "степени сложности. Урок подходит для людей с разным уровнем подготовки.",
                        Level = context.TrainingLevels.Get(3),
                        ProgramType = context.ProgramTypes.Get(4)
                    },
                    new PayTraining()
                    {
                        TrainingName = "Шпагат", TrainingDescription ="Занятие включает в себя комплекс упражнений, направленных на улучшение эластичности " +
                                                                      "мышц, подвижность суставов, что позволит вам легко садиться на продольный и поперечный " +
                                                                      "шпагат",
                        Level = context.TrainingLevels.Get(3),
                        ProgramType = context.ProgramTypes.Get(4),
                        PlacesCount = 5
                    },
                    new TrainingData()
                    {
                        TrainingName = "#Superпресс", TrainingDescription ="Занятие направлено на укрепление брюшного пресса и спины. Сочетает в себе разминку, " +
                                                                           "разогревающую позвоночник, суставы и непосредственно мышцы живота и спины , и комплекс упражнений, позволяющий быстро " +
                                                                           "и эффективно проработать все мышцы брюшного пресса и спины.",
                        Level = context.TrainingLevels.Get(2),
                        ProgramType = context.ProgramTypes.Get(3)
                    }
                });
            }

            //если нет тренировки в расписании
            if (!context.Trainings.GetAll().Any())
            {
                context.Trainings.AddRange(new List<Training>()
                {
                    #region Тренировки на первый день
                  
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Здоровая спина")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 0
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "STEP ABS")
                    },
                     new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "#запускягодицы")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Upper Body")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Stretch")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Callanetics")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "STEP INTERVAL")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 1
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Hatha Yoga")
                    },
                    #endregion

                    #region Тренировки на второй день
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 9, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 2
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 9, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Здоровая спина")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 10, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "#Superпресс")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 11, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "#запускягодицы")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 11, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 3
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 14, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Tabata")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 15, 0, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Callanetics")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 17, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "ABS and Stretch")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 17, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Шпагат"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 3
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 18, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(1),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "#запускягодицы")
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 18, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX"),
                        PlacesCount = ((PayTraining) context.TrainingDatas.Find(tr=>tr.TrainingName == "TRX")).PlacesCount,
                        BusyPlacesCount = 4
                    },
                    new Training()
                    {
                        StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1 , 19, 30, 0),
                        Minutes = 55,
                        Gym = context.Gyms.Get(2),
                        TrainingData = context.TrainingDatas.Find(tr=>tr.TrainingName == "Hatha Yoga")
                    }
                    #endregion
                });
            }

            ////если нет таблицы TrainingDataTrainings
            //if (!context.TrainingDataTrainings.GetAll().Any())
            //{
            //    context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(1).Id, TrainingId = context.Trainings.Get(1).Id });
            //    context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(2).Id, TrainingId = context.Trainings.Get(2).Id });
            //    context.Trainings.Get(1).TrainingDataTrainings.Add(new TrainingDataTraining() { TrainingDataId = context.TrainingDatas.Get(3).Id, TrainingId = context.Trainings.Get(3).Id });
            //    //создаем замененную тернировку
            //    context.Trainings.Get(1).ReplcedTrainings.Add(new ReplcedTraining() { TrainingDataId = context.TrainingDatas.Get(4).Id, TrainingId = context.Trainings.Get(4).Id });
            //}

            //Создадим клиента
            if (!context.Clients.GetAll().Any())
            {
                context.Clients.AddRange(new List<Client>()
                {
                    new Client(){Family = "Куликов", Name = "Антон",LastName = "Юрьевич",
                                 DateOfBirdth = DateTime.Parse("24.03.2000"),
                                 Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"kulikov.png","\\InitializeData\\HumanPhoto\\"),
                                 AbonementStatus = context.AbonementStatuses.Get(1),
                                 AbonementType =  context.AbonementTypes.Get(3),
                                 AbonementDateOfRegistration = DateTime.Now,
                                 AbonementNumber = AbonementGenerator.CreateNumberSubscription(context),
                                 PasportData = $"2409 N460870 ОУФМС РОССИИ {DateTime.Parse("04.05.2012")}",
                                 PasswordHash = "2705",
                                 AbonementStatusId =  context.AbonementStatuses.Get(1).Id,
                                 AbonementActionTime =  DateTime.Parse("30.05.2019"),
                                 AbonementDateOfActivate =  DateTime.Now

                    }
                });
            }

            //добавим тренировки клиенту по предварительной записи
            if (!context.TrainingClients.GetAll().Any())
            {
                context.Clients.Get(1).TrainingClients.Add(new TrainingClient() { ClientId = context.Clients.Get(1).Id, TrainingId = context.Trainings.Get(2).Id });
                context.Complete(); //сохраняем изменения
            }

            //проинициализируем роли пользователей системы
            if (!context.Roles.GetAll().Any())
            {
                context.Roles.AddRange(new List<Role>
                {
                    new Role() {Description = "Инструктор групповых программ"},
                    new Role() {Description = "Администратор"},
                    new Role() {Description = "Клиент"}
                });
            }

            //добавим тренеров
            if (!context.Employees.GetAll().Any())
            {
                context.Employees.AddRange(new List<Employee>()
                {
                    new Employee() {Name = "Галина", Family = "Елизарова",LastName ="Семеновна",Login = "gal", PasswordHash = "hash1", DateOfBirdth = DateTime.Parse("10.05.1978"),Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"elizarova-galina.jpg"),
                                                                                                                Desc = "К йоге я пришла более 10 лет назад. И как мне казалось случайно. " +
                                                                                                               "Больше всего, изначально, меня зацепило то, что мой преподаватель " +
                                                                                                               "постоянно повторял:«Йога не для всех, она сама выбирает, кто в ней " +
                                                                                                               "останется, а кто уйдет»! Я говорила себе - так, что значит, йога меня выберет " +
                                                                                                               "или нет,-захочу и буду заниматься. И каждый раз, когда мне было лень идти на практику " +
                                                                                                               "я вспоминала именно эти слова и то, что я сама, вроде как, решила заниматься йогой," +
                                                                                                               "собиралась и шла практиковать"},
                    new Employee() {Name = "Анастасия", Family = "Молькова",LastName ="Сергеевна", DateOfBirdth = DateTime.Parse("10.01.1979"),Login = "ana", PasswordHash = "ana1", Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"Molkova Anastasija.jpg"),
                                                                                                                Desc = "Инструктор групповых порграмм. Персональный тренер зала ГП. Составление тренировочных программ и " +
                                                                                                                "стиля питания для корректировки фигуры. Сертифицированный тренер TRX."},
                    new Employee() {Name = "Елена", Family = "Куликова", LastName ="Алексеевна", Login = "ele", PasswordHash = "ele1", DateOfBirdth = DateTime.Parse("10.03.1965"), Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"kulikova_elena2.jpg"),
                                                                                                                Desc = "Инструктор групповых порграмм. Составление программ по снижению веса и коррекции фигуры, повышение " +
                                                                                                                "выносливости,развитие гибкости. Силовые уроки, степ-аэробика, каланетика в зале."},
                    new Employee() {Name = "Полина", Family = "Соловьева",LastName = "Николаева",Login = "pol", PasswordHash = "pol1", DateOfBirdth = DateTime.Parse("10.04.1985"), Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"Soloveva Polina.jpg"),
                                                                                                                Desc = "Инструктор групповых порграмм. Уроки мягкого фитнеса в зале групповых программ. Составление индивидуальных " +
                                                                                                               "программ по развитию гибкости мышц, связок и позвоночника. Тренер тренажерного зала."},
                    new Employee() {Name = "Ершова", Family = "Анастасия",LastName = "Олеговна",Login = "an",   PasswordHash = "an1", DateOfBirdth = DateTime.Parse("14.02.1987"),Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"erchova anastasya.jpg"),
                                                                                                                Desc = "Инструктор групповых порграмм. Персональный тренер. Член национального союза фитнеса."},

                    new Employee() {Name = "Ольга", Family = "Осипова",LastName = "Антоновна", Login = "ol",    DateOfBirdth = DateTime.Parse("14.02.1980"),PasswordHash = "ol1",Role = context.Roles.Get(1),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"Osipova Olga.jpg"),
                                                                                                                Desc = "Мастер-тренер тренажерного зала. Составление программ по снижению веса и коррекции фигуры; " +
                                                                                                                "танцевальные программы, мягкий фитнес; силовые программы в зале групповых программ. Сертифицированый инструктор " +
                                                                                                                "по пилатесу,функциональному тренингу, силовым программам и зумбе"},
                    new Employee() {Name = "Ольга", Family = "Винник",LastName = "Сергеевна", Login = "ov",     PasswordHash = "ov1",Role = context.Roles.Get(1), DateOfBirdth = DateTime.Parse("14.02.1980"),
                                                                                                                Photo = SqlTools.ConvertImageToByteArray(SqlTools.GetPath(),"vinnik_2.jpg"),
                                                                                                                Desc = "Победитель шейпинг-конкурса «Пигмалион и Галатея« 2014 год (проводится под эгидой Федерации шейпинга среди клубов с лицензированным шейпигом) в номинации «Шейпинг-модель»."}

                });
            }

            //добавим тренера к тренировке
            if (!context.CoachesTrainings.GetAll().Any())
            {
                #region Тренировки на первый день
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(1).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(2).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(3).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(4).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(4).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(5).Id, CoachId = context.Employees.Get(4).Id });
                context.Employees.Get(4).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(6).Id, CoachId = context.Employees.Get(4).Id });
                context.Employees.Get(4).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(7).Id, CoachId = context.Employees.Get(4).Id });
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(8).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(9).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(1).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(10).Id, CoachId = context.Employees.Get(1).Id });
                #endregion

                #region Тренировки на второй день
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(11).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(12).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(13).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(14).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(15).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(5).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(16).Id, CoachId = context.Employees.Get(5).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(17).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(4).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(18).Id, CoachId = context.Employees.Get(4).Id });
                context.Employees.Get(6).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(19).Id, CoachId = context.Employees.Get(6).Id });
                context.Employees.Get(2).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(20).Id, CoachId = context.Employees.Get(2).Id });
                context.Employees.Get(1).CoachTrainings.Add(new CoachTraining() { TrainingId = context.Trainings.Get(21).Id, CoachId = context.Employees.Get(1).Id });
                #endregion

            }

            context.Complete(); //сохраняем изменения

            ////https://www.youtube.com/watch?v=oDz7ku6fRkg
        }
    }
}