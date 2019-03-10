namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Employee : Human
    {
        public string Login { get; set; } //логин

        public string PasswordHash { get; set; }//хэш пароля

        public string Desc { get; set; }//описание
    }
}
