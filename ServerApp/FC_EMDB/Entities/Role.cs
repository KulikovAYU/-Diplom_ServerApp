using System;
using System.Collections.Generic;
using System.Text;

namespace FC_EMDB.Entities.Entities
{
    /// <summary>
    /// Сущность "Роль"
    /// </summary>
    public class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; } //описанеие

        /// <summary>
        /// Свойство навигации
        /// </summary>
        private ICollection<Employee> Employees;
    }
}
