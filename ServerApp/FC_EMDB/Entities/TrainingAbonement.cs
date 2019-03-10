using System;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс посещение 1..* Training -> 1..* Abonement
    /// </summary>
    public class TrainingAbonement
    {
        public DateTime ComeInTime { get; set; }//время входа
        public DateTime ComeOutTime { get; set; }//время выхода

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int AbonementId { get; set; }
        public Abonement Abonement { get; set; }
    }
}
