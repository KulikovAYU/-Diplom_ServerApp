namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Платная тренировка
    /// </summary>
   public class PayTraining : TrainingData
    {
        public PayTraining()
        {
            IsMustPay = true;
        }

        public int PlacesCount { get; set; }//количество записей (вместимость)

        public int FreePlacesCount { get; set; }//количество свободных мест

        public int BusyPlacesCount { get; set; }// количество занятых мест
    }
}
