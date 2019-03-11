using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс сущности тренер
    /// </summary>
    public class Coach : Employee
    {
        public ICollection<CoachTraining> CoachTrainings { get; set; }

        public Coach()
        {
            CoachTrainings = new HashSet<CoachTraining>();
            
        }
    }
}
