using System;
using System.Collections.Generic;

namespace FC_EMDB.Entities.Entities
{
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; } //имя

        public string Family { get; set; } //фамилия

        public string LastName { get; set; } //отчество

        public DateTime DateOfBirdth { get; set; }
        //public string mCoachDesc { get; set; }

        public byte[] Photo { get; set; }

        public string Desc { get; set; }//описание

        public string Login { get; set; }

        public string PasswordHash { get; set; }


        public User()
        {
            Employees = new HashSet<Employee>();
            Clients = new HashSet<Client>();
           
        }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        private ICollection<Employee> Employees;

        public int EmployeesId { get; set; }

        /// <summary>
        /// Свойство навигации
        /// </summary>
        private ICollection<Client> Clients;

        public int ClientsId { get; set; }

        /// <summary>
        /// Свойство навиггации
        /// </summary>
         public Role Role { get; set; }

        public int RolesId { get; set; }
    }
}
