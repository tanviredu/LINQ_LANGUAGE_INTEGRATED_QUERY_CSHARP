using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_Cars
{
    public class Car
    {
        // adding the Id column to support the 
        // entity framework
        [Key]
        public int Id { get; set; }
        // creating properties
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }

        public int Combined { get; set; }

        // take a row and make it a car object

    }

}
