using System;

namespace JsonConverters.JSONEntities
{
    public class JSONTraining
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; } //время начала

        public DateTime EndTime { get; set; } //время окончания тренировки

        public string TrainingName { get; set; }//название тренировки

        public bool IsFinished { get; set; } = false;//признак законченной тренировки

        public string GymName { get; set; }//название зала

        public string LevelName { get; set; }//уровень

        public int CoachId { get; set; }//id инструктора

        public string CoachName { get; set; }//имя инструктора

        public string CoachFamily { get; set; }//фамилия инструктора

        public string Description { get; set; }// описание тренера

        public bool IsReplaced { get; set; }//заменена ли тренировка ПОДУМАТЬ!!!!!

        public bool IsMustPay { get; set; } = false; //платная

        public bool IsNewTraining { get; set; } // признак новой тренировки

        public string ProgramType { get; set; } //тип программы

        public bool Ispopular { get; set; } = false;//признак популярности

        public int PlacesCount { get; set; }//количество записей (вместимость)

        public int FreePlacesCount { get; set; }//количество свободных мест

        public int BusyPlacesCount { get; set; }// количество занятых мест





    }
}
