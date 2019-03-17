using System;

namespace FC_EMDB.Entities.Entities
{
    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; } //имя

        public string Family { get; set; } //фамилия

        public string LastName { get; set; } //отчество

        public DateTime DateOfBirdth { get; set; }
        //public string mCoachDesc { get; set; }

        public byte[] Photo { get; set; }
    }
}
