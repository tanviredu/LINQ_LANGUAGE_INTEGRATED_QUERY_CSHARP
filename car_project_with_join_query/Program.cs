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

            // if we want to know
            // the max combined
            // min combained
            // and the avg combined

            var query = from car in cars
            group car by car.Manufacturer into cargroup
            select new{
                Name = cargroup.Key, // manufacturer
                Max  = cargroup.Max(c => c.Combined),
                Min  = cargroup.Min(c => c.Combined),
                Avg  = cargroup.Average(c =>c.Combined)
            };
            



            // printting
            foreach (var result in query){
                Console.WriteLine($" MANUFACTURER : {result.Name}");
                Console.WriteLine($"     MAX :{result.Max,-3}");
                Console.WriteLine($"     MIN :{result.Min,-3}");
                Console.WriteLine($"     AVG :{result.Avg, -3}");
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
