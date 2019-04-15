using System;
using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
   public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } //имя

        public string Family { get; set; } //фамилия

        public string LastName { get; set; } //отчество

        public DateTime DateOfBirdth { get; set; }
        //public string mCoachDesc { get; set; }

        public byte[] Photo { get; set; }

        public Client()
        {
            TrainingClients = new HashSet<TrainingClient>();
            VisitedTrainingClients = new HashSet<VisitedTrainingClient>();
            ClientsFcmInfos = new HashSet<ClientsFcmInfo>();
        }

        public string PasportData { get; set; } //паспортные данные

        public int AbonementNumber { get; set; } //номер абонемента

        public string PasswordHash { get; set; }//пароль

        public DateTime AbonementDateOfRegistration { get; set; } //дата регистрации

        public DateTime AbonementDateOfActivate { get; set; } //дата активации

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

        public ICollection<TrainingClient> TrainingClients { get; set; }

        public ICollection<VisitedTrainingClient> VisitedTrainingClients { get; set; }

        public ICollection<ClientsFcmInfo> ClientsFcmInfos { get; set; }
    }
}
