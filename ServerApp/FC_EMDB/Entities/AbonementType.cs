using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Тип абонемента
    /// </summary>
   public class AbonementType
    {
        public AbonementType()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Name { get; set; } //имя

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public ICollection<Client> Clients { get; set; }
    }
}
