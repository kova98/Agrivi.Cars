using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models
{
    public class Trip
    {
        public Customer Customer { get; set; }

        public Taxi Taxi { get; set; }

        public int Price { get; set; }
    }
}
