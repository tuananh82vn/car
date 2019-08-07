using System;
using System.Collections.Generic;
using System.Text;

namespace CarSales_Mini.DAL.Entities
{
    public class Car : Vehicle
    {
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string BodyType { get; set; }

    }
}
