using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FC_EMDB;
using FC_EMDB.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }



        /// <summary>
        /// Получить список тренировок на выбранный день
        /// </summary>
        /// <param name="date">Выбранная дата</param>
        /// <returns>Список тренировок</returns>
        [HttpGet]
        [Route("gettrainingsList/{date}")]
        public ActionResult<IEnumerable<Training>> Get(DateTime date)
        {

            var list = new List<Training>();

            //Training item1 = new TrainingBuilder().Name("Hatha Yoga").
            //     StartTime(new DateTime(2019, 2, 8, 7, 30, 0)).
            //     EndTime(new DateTime(2019, 2, 8, 8, 30, 0)).
            //     GymName("Большой зал").
            //     ProgramType("Mind&Body (Мягкий фитнес)").
            //     LevelName("Низкая интенсивность").
            //     CoachName("Галина").
            //     CoachFamily("Елизарова").
            //     Description("Занятие, на котором помимо асан и пранаямы делается акцент на " +
            //             "концентрацию внимания и медитацию. Урок рекомендован для всех уровней подготовки").
            //     Build();

            //list.Add(item1);


            ////addItem(item1);


            //Training item2 = new TrainingBuilder().Name("TRX").
            //        StartTime(new DateTime(2019, 2, 8, 8, 30, 0)).
            //        EndTime(new DateTime(2019, 2, 8, 9, 30, 0)).
            //        GymName("Тренажерный зал").
            //        ProgramType("Специальные программы").
            //        LevelName("Для всех уровней подготовки").
            //        CoachName("Анастасия").
            //        CoachFamily("Молькова").
            //        Description("TRX - тренировка мышц всего тела с помощью уникального оборудования - " +
            //                "TRX-петель. Это тренировка, которая позволяет не только развивать все мышечные группы, " +
            //                "укреплять связки и сухожилия, но и развивать гибкость, ловкость, выносливость и многое " +
            //                "другое. Данная тренировка имеет еще одно важное достоинство - эффективное развитие мышц так " +
            //                "называемого кора(мышц-стабилизаторов). Упражнения подходят для всех возрастных групп, " +
            //                "для мужчин и женщин, для лиц с отклонениями в состоянии здоровья, так как в этой тренировке " +
            //                "нет никакой осевой (вертикальной) нагрузки на позвоночник").
            //        Capacity(10).IsMustPay().Capacity(10).BusyPlacesCount(5).
            //        Build();
            //list.Add(item2);

            //Training item3 = new TrainingBuilder().Name("New Body").
            //        StartTime(new DateTime(2019, 2, 8, 10, 00, 0)).
            //        EndTime(new DateTime(2019, 2, 8, 10, 30, 0)).
            //        GymName("Большой зал").
            //        ProgramType("Силовой и функциональный тренинг").
            //        LevelName("Для всех уровней подготовки").
            //        CoachName("Елена").
            //        CoachFamily("Куликова").
            //        IsNewTraining().
            //        Description("NEW BODY (55 мин) («Новое тело») - силовой урок, направленный на тренировку всех " +
            //                "групп мышц. Специально подобранные комплексы упражнений помогут скорректировать проблемные зоны, " +
            //                "независимо от того, каким телосложением вы обладаете. Урок рекомендован как для среднего так и для " +
            //                "продвинутого уровня подготовки").
            //        Build();
            //list.Add(item3);

            //Training item4 = new TrainingBuilder().Name("ABS+Stretch").
            //        StartTime(new DateTime(2019, 2, 8, 16, 00, 00)).
            //        EndTime(new DateTime(2019, 2, 8, 16, 30, 00)).
            //        GymName("Большой зал").
            //        ProgramType("Mind&Body (Мягкий фитнес)").
            //        LevelName("Для всех уровней подготовки").
            //        CoachName("Елена").
            //        CoachFamily("Куликова").
            //        Replaced().
            //        Description("Урок, направленный на развитие гибкости, с использованием специальных упражнений на растягивание. " +
            //                "Увеличивает подвижность суставов, эластичность связок, дает общее расслабление и релаксацию.").
            //        Build();
            //list.Add(item4);

            //Training item5 = new TrainingBuilder().Name("Pilates").
            //        StartTime(new DateTime(2019, 2, 8, 17, 30, 00)).
            //        EndTime(new DateTime(2019, 2, 8, 18, 30, 00)).
            //        GymName("Большой зал").
            //        LevelName("Для всех уровней подготовки").
            //        CoachName("Полина").
            //        CoachFamily("Соловьева").
            //        ProgramType("Mind&Body (Мягкий фитнес)").
            //        Description("Урок направлен на укрепление мышц-стабилизаторов, упражнгения пилатес " +
            //                "способствуют снятию напряжению с позвоночника, восстановлению эластичности " +
            //                "связочного аппарата и мышц. Урок рекомендован для всех уровней подготовки").
            //        IsPopular().
            //        Build();
            //list.Add(item5);

            if (list == null)
                return NotFound();

            return Ok(list);
        }

        //[HttpGet("{id}")]
        ////[Route("Trainings1/{id}")]
        //public ActionResult<Coach> Get(int id, string mnTrtainingId)
        //{
        //    return new Coach() { mCoachName = "Иван", mCoachFamily = "Иванов", mCoachDesc = "Описагние тренера" };
        //}



        //[HttpPost]
        //public void Post([FromBody]MyClass currentTraining)
        //{
        //    new Coach() { mCoachName = "Иван", mCoachFamily = "Иванов", mCoachDesc = "Описагние тренера" };
        //}

        /// <summary>
        /// Получить информацию о тренере по конкретной тренировке
        /// </summary>
        /// <param name="currentTraining">Текущая тренировка</param>
        /// <returns>Тренер</returns>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody]Training currentTraining)
        {
            return Ok(/*new Coach() { mCoachName = "Иван", mCoachFamily = "Иванов", mCoachDesc = "Описагние тренера" }*/);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public ActionResult<Coach> Post([FromBody] string value)
        //{
        //    int n = 0;
        //    return null;
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    //public class MyClass
    //{
    //    public string mName { get; set; }
    //}
}
