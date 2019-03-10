using System;
using System.Drawing;

namespace FC_EMDB.Entities.Entities
{
    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public DateTime DateOfBirdth { get; set; }
        //public string mCoachDesc { get; set; }

        public Bitmap Photo { get; set; }
    }
}
