using System;
using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
   public class Client : Human
    {

        public Client()
        {
            TrainingClients = new HashSet<TrainingClient>();

        }
        public string PasportData { get; set; } //паспортные данные

        public int AbonementNumber { get; set; } //номер абонемента

        public string PasswordHash { get; set; }//пароль

        public DateTime AbonementDateOfRegistration { get; set; } //дата регистрации
        public DateTime AbonementActionTime { get; set; } //кол-во месяцев

        /// <summary>
        /// Навигация Abonement 1..*-> 1..1 AbonementStatus
        /// </summary>
        public int AbonementStatusId { get; set; }//(Внешний ключ)
        public AbonementStatus AbonementStatus { get; set; }

        /// <summary>
        /// Навигация Abonement 1..1 -> 1..1 AbonementTypeId
        /// </summary>
        public int AbonementTypeId { get; set; }//id абонемента (Внешний ключ)
        public AbonementType AbonementType { get; set; } //свойство навигации

        public ICollection<TrainingClient> TrainingClients;
   }
}
