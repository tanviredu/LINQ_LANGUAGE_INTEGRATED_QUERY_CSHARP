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
            // we make a group querty
            // group by manufacturer
            // in the grouping there is no select question
            // group by dont need to be end in select
            var query = from car in cars 
                        group car by car.Manufacturer;

            
            // to print the grouping 
            // we need to prin differently
            // foreach (var result in query.Take(3)){
            //     // lets see the count and the key

            //     Console.WriteLine($"{result.Key} has {result.Count()} cars");
            // }

            // we can further group here in side the forloop






            // foreach(var group in query){
            //     Console.WriteLine($"Group : {group.Key,-6}");

            //     // innner loop we iterate the value
            //     foreach(var car in group.OrderByDescending(c => c.Combined).Take(3)){
            //         Console.WriteLine($"\t Car Name : {car.Name} : {car.Combined} ");
            //     }
            // }



            // wif you can do more thing after groupping
            var query4 = from car in cars 
                        group car by car.Manufacturer.ToUpper()
                        into  m
                        orderby m.Key
                        select m;


            // and we can do it with function too
            var query5 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                            .OrderBy(g =>g.Key);




             foreach(var group in query5){
                Console.WriteLine($"Group : {group.Key,-6}");

                // innner loop we iterate the value
                foreach(var car in group.OrderByDescending(c => c.Combined).Take(3)){
                    Console.WriteLine($"\t Car Name : {car.Name} : {car.Combined} ");
                }
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
