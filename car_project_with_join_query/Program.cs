using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace car_project_with_join_query
{
    class Program
    {
        static void Main(string[] args)
        {
           // we make this csv file into a collection of
           // cars
           // every row will be a car object
           // we need to  omit the column
           var cars = ProcessFilequery("fuel.csv");
           var manufacturers = ProcessFilesecond("manufacturers.csv");


            // make a fucntion to get all the 
            // object

            // make a query
            var query2 = from car in cars 
            orderby car.Name ascending
            select car.Name;


            foreach(var car in query2.Take(10)){
                Console.WriteLine($"Car Name : {car}");
            }
            
            var query4 = from manufacturer in manufacturers 
            orderby manufacturer.Name ascending
            select manufacturer.Name;


            foreach(var manufacturer in query4.Take(10)){
                Console.WriteLine($"ManuFacturer Name : {manufacturer}");
            }

            
        }

        private static List<Manufacturer> ProcessFilesecond(string path)
        {
            var query3 = File.ReadAllLines(path).Where(l => l.Length >1)
                            .Select(l => {
                                var data = l.Split(",");
                                return new Manufacturer{
                                    Name = data[0],
                                    Headquarters = data[1],
                                    Year = int.Parse(data[2])
                                };
                            });
            return query3.ToList();
            
        }

        // return a list of cars

        /// we can make th same thing without the extension
        /// method using just query method

        private static List<Car> ProcessFilequery(string path){
            var query2 = from row in File.ReadAllLines(path).Skip(1)
            where row.Length >1
            select Car.ParseFromCsv(row);

            return query2.ToList();
        }


    }
}
