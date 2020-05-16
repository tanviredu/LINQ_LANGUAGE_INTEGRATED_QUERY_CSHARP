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

            // make a join query
            // we make a non  object
            var query = from car in cars 
                join manufacturer in manufacturers
                on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending,car.Name ascending
                select new {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined

                };

                foreach(var car in query.Take(3)){
                    Console.Write($" Name : {car.Name,-6} Headquerters: {car.Headquarters,-6} \n");


                }


                var query2 = cars.Join(manufacturers,
                    c => c.Manufacturer,m => m.Name,(c,m) => new{
                        m.Headquarters,
                        c.Name,
                        c.Combined
                    }
                ).OrderByDescending(c => c.Combined).ThenBy(c =>c.Name);
            Console.WriteLine("---------------------------------------------------");
            foreach(var car in query2.Take(3)){
                    Console.Write($" Name : {car.Name,-6} Headquerters: {car.Headquarters,-6} \n");


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
