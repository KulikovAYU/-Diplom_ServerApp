namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность описание тренировки
    /// </summary>
    public class Description
    {
        public int Id { get; set; }

        public string Desc { get; set; }

        public Training Training { get; set; }
    }
}
