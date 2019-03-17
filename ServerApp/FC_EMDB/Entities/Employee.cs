using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Employee : Human
    {
        public Employee()
        {
            CoachTrainings = new HashSet<CoachTraining>();
        }

        public string Login { get; set; } //логин

        public string PasswordHash { get; set; }//хэш пароля

        public string Desc { get; set; }//описание

        /// <summary>
        /// Свойство навиггации
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        public ICollection<CoachTraining> CoachTrainings { get; set; }

    }
}
