using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс сущности тренер
    /// </summary>
    public class Coach : Employee
    {
        public ICollection<CoachTraining> CoachTraining { get; set; }

        public Coach()
        {
            CoachTraining = new HashSet<CoachTraining>();
            
        }
    }
}
