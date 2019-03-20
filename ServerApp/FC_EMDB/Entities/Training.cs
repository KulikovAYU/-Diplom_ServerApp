using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность тренировки в расписании
    /// </summary>
    public class Training
    {
        public ICollection<CoachTraining> CoachTrainings { get; set; }
        public ICollection<TrainingClient> TrainingClients { get; set; }
        public ICollection<ReplcedTraining> ReplcedTrainings { get; set; }
       
        public ICollection<VisitedTrainingClient> VisitedTrainingDataTrainings { get; set; }
        public TrainingData TrainingData { get; set; }


        public Training()
        {
            CoachTrainings = new HashSet<CoachTraining>();
            TrainingClients = new HashSet<TrainingClient>();
            ReplcedTrainings = new HashSet<ReplcedTraining>();
            VisitedTrainingDataTrainings = new HashSet<VisitedTrainingClient>();
        }

        public int Id { get; set; } //id тренировки

        public DateTime StartTime { get; set; }//время начала

        public DateTime EndTime { get; set; }//время окончания тренировки

        public bool IsReplaced { get; set; }//заменена ли тренировка

        private double minutes;
        [NotMapped]
        public double Minutes {
            get => minutes;
            set { minutes = value;
                var buf = minutes;
                EndTime = StartTime;
                EndTime = EndTime.AddMinutes(55);
            }
        }

        [NotMapped]
        private bool bIsFinished; 

        public bool IsFinished
        {
            get=> bIsFinished;
            set
            {
                bIsFinished = value;
                bIsFinished = EndTime.Day == DateTime.Now.Day && EndTime.DayOfWeek == DateTime.Now.DayOfWeek &&
                              EndTime.Year == DateTime.Now.Year;
            }
        } //признак законченной тренировки

    
        /// <summary>
        /// Навигация Training 1..* -> 1..1 Gym
        /// </summary>
        public int GymId { get; set; }
        public Gym Gym { get; set; }
      
    }
}
