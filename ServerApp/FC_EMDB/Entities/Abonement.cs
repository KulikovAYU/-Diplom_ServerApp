using System;
using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    public class Abonement
    {
        public ICollection<TrainingAbonement> TrainingAbonements { get; set; }
        public ICollection<PreRegistration> PreRegistrations { get; set; }

        public Abonement()
        {
            TrainingAbonements = new HashSet<TrainingAbonement>();
            PreRegistrations = new HashSet<PreRegistration>();
        }

        public int Id { get; set; }
        public int Number { get; set; }

        public DateTime DateOfRegistration { get; set; } //дата регистрации
        public DateTime CountDays { get; set; } //кол-во месяцев


        /// <summary>
        /// Навигация Abonement 1..*-> 1..1 AbonementStatus
        /// </summary>
        public int AbonementStatusId { get; set; }//(Внешний ключ)
        public AbonementStatus AbonementStatus { get; set; }


        /// <summary>
        /// Навигация Abonement 1..1 -> 1..1 Client
        /// </summary>
        public int ClientId { get; set; } //id клиента (Внешний ключ)
        public Client Client { get; set; } //свойство навигации


        /// <summary>
        /// Навигация Abonement 1..1 -> 1..1 AbonementTypeId
        /// </summary>
        public int AbonementTypeId { get; set; }//id абонемента (Внешний ключ)
        public AbonementType AbonementType { get; set; } //свойство навигации
    }
}
