namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Тип абонемента
    /// </summary>
   public class AbonementType
    {
        public int Id { get; set; }
        public string Name { get; set; } //имя

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public Abonement Abonement { get; set; }
    }
}
