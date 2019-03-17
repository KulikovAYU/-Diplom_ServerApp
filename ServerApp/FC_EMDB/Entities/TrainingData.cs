using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность данные о тренировке
    /// </summary>
    public class TrainingData
    {
        public TrainingData()
        {
            TrainingDataTrainings = new HashSet<TrainingDataTraining>();
            ReplacingDatas = new HashSet<ReplcedTraining>();
        }

        public int Id { get; set; } //id тренировки
        public string TrainingName { get; set; }//название тренировки
        public string TrainingDescription { get; set; } //описание
        public string LevelName { get; set; }//уровень
        public bool IsMustPay { get; set; } = false;//платная
        public string ProgramType { get; set; }//тип программы
        public bool IsNewTraining { get; set; } //новая тренировка
        public bool Ispopular { get; set; }//признак популярности

        public ICollection<TrainingDataTraining> TrainingDataTrainings { get; set; }
        public ICollection<ReplcedTraining> ReplacingDatas { get; set; }
    }
}
