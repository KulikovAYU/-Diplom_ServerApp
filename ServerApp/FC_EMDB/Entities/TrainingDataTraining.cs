namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Расписание тренировок
    /// </summary>
    public class TrainingDataTraining
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int TrainingDataId { get; set; }
        public TrainingData TrainingData { get; set; }
    }
}
