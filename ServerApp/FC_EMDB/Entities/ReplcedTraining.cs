namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Замененные тренировки
    /// </summary>
    public class ReplcedTraining
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int? TrainingDataId { get; set; }
        public TrainingData TrainingData { get; set; }
    }
}
