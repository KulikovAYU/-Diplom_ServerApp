namespace FC_EMDB.Entities.Entities
{
   public class Client : Human
    {
        public string PasportData { get; set; } //паспортные данные

        public int Login { get; set; } //логин

        public string PasswordHash { get; set; }//пароль

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public Abonement Abonement { get; set; }
    }
}
