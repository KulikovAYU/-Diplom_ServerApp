using System;
using System.Collections.Generic;


namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность тренировки
    /// </summary>
    public class Training
    {
        public ICollection<CoachTraining> CoachTrainings { get; set; }
        public ICollection<TrainingAbonement> TrainingAbonements { get; set; }

        public ICollection<PreRegistration> PreRegistrations { get; set; }

        public Training()
        {
            CoachTrainings = new HashSet<CoachTraining>();
            TrainingAbonements = new HashSet<TrainingAbonement>();
            PreRegistrations = new HashSet<PreRegistration>();
        }

        public int Id { get; set; } //id тренировки

        public DateTime StartTime { get; set; }//время начала

        public DateTime EndTime { get; set; }//время окончания тренировки

        public string TrainingName { get; set; }//название тренировки

        public bool IsFinished { get; set; }//признак законченной тренировки

        //public string mGymName { get; set; } //название зала //в сущность

        public string LevelName { get; set; }//уровень

        //public string mCoachName { get; set; }//имя инструктора //в сущность

        //public string mCoachFamily { get; set; }//фамилия инструктора //в сущность

        public string mDescription { get; set; }// описание

        public bool IsReplaced { get; set; }//заменена ли тренировка

        public bool IsMustPay { get; set; }//платная

        public string ProgramType { get; set; }//тип программы

        public bool IsNewTraining { get; set; } //новая тренировка

        public bool Ispopular { get; set; }//признак популярности

        public int PlacesCount { get; set; }//количество записей (вместимость)

        public int FreePlacesCount { get; set; }//количество свободных мест

        public int BusyPlacesCount { get; set; }// количество занятых мест

        /// <summary>
        /// Навигация Training 1..* -> 1..1 Gym
        /// </summary>
        public int GymId { get; set; }
        public Gym Gym { get; set; }
    }
}
