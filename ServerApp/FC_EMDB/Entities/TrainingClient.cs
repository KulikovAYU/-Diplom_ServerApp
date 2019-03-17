using System;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс посещение 1..* Training -> 1..* Client
    /// </summary>
    public class TrainingClient
    {
        public DateTime ComeInTime { get; set; }//время входа
        public DateTime ComeOutTime { get; set; }//время выхода
        public bool IsComeIn { get; set; } //пришел

        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
