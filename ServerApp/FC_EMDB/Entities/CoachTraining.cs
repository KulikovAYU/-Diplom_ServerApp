namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// таблица связей многие ко многим (тренер - тренировка)
    /// </summary>
    public class CoachTraining
    {
        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
