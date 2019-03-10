using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность зал
    /// </summary>
    public class Gym
    {
        public ICollection<Training> Trainings { get; set; } //абонемскенты

        public Gym()
        {
            Trainings = new HashSet<Training>();
        }
        public int Id { get; set; }

        public string Name { get; set; } //имя зала

        public int Capacity { get; set; }//вместимость зала
    }
}
