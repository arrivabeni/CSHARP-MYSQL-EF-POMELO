using System;
using System.Collections.Generic;

namespace com.mynamespace
{
    public partial class Addresses
    {
        public int Idaddresses { get; set; }
        public int? Idemployee { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Employees IdemployeeNavigation { get; set; }
    }
}
