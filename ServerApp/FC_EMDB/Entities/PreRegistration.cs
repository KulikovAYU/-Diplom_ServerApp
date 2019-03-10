namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность предварительной регистрации (мои занятия) Training 1..*->1..* Abonement
    /// </summary>
    public class PreRegistration
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int AbonementId { get; set; }
        public Abonement Abonement { get; set; }
    }
}
