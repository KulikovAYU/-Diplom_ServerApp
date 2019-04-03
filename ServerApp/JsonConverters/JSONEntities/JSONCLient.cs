using System;

namespace JsonConverters.JSONEntities
{
   public class JSONClient
    {
        public int Id { get; set; }

        public string Name { get; set; } //имя

        public string Family { get; set; } //фамилия

        public string LastName { get; set; } //отчество

        public DateTime DateOfBirdth { get; set; }//дата рождения

        public int AbonementNumber { get; set; } //номер абонемента

        public string AbonementType { get; set; } //тип абонемента

        public string AbonementStatus { get; set; } //статус абонемента

        public DateTime AbonementDaysFreezeCount { get; set; }//дни заморозки

        public DateTime AbonementActionTime { get; set; } //дата действия абонемента

        public DateTime AbonementEndTime { get; set; }//активно до

        public bool IsAсtive { get; set; } //активен

        public bool IsFreeze { get; set; } //заморожен
    }
}
