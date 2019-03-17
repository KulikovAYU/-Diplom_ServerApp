using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
  public  class TrainingLevel
  {
      public TrainingLevel()
      {
          TrainingDatas = new HashSet<TrainingData>();
      }
      public int Id { get; set; }

      public string Name { get; set; } //имя уровня

      public ICollection<TrainingData> TrainingDatas { get; set; }
  }
}
