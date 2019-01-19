using System;
using System.Collections.Generic;

namespace com.mynamespace
{
    public partial class Employees
    {
        public Employees()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Idemployees { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthdate { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
