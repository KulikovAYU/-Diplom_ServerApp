using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность тип программы
    /// </summary>
   public class ProgramType
    {
        public ProgramType()
        {
            TrainingDatas = new HashSet<TrainingData>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TrainingData> TrainingDatas { get; set; }
    }
}
