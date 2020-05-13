using System;

namespace cars_project{
    public class Car{
        

        // creating properties
        public int Year {get;set;}
        public string Manufacturer {get;set;}
        public string Name{get;set;}
        public double Displacement {get;set;}
        public int Cylinders {get;set;}
        public int City {get;set;}
        public int Highway {get;set;} 

        public int Combined{get;set;}

        // take a row and make it a car object
        internal static Car ParseFromCsv(string row)
        {
            // split the row element
            var columns = row.Split(',');
            // then this column wil be a array of different value
            return new Car{

                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7]),
            };
        }
    }

}