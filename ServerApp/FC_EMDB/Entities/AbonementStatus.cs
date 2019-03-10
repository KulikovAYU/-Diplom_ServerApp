using System;
using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Статус абонемента: действующий, либо приостановлен
    /// </summary>
    public class AbonementStatus
    {

        public AbonementStatus()
        {
            Abonements = new HashSet<Abonement>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DaysCount { get; set; } //срок заморозки

        public ICollection<Abonement> Abonements { get; set; } //абонементы
    }
}
