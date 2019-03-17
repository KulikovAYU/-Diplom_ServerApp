using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Статус абонемента: действующий, либо приостановлен
    /// </summary>
    public class AbonementStatus
    {

        public AbonementStatus()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        
        public DateTime DaysFreezeCount { get; set; } //срок заморозки

        public ICollection<Client> Clients { get; set; } //абонементы
    }
}
