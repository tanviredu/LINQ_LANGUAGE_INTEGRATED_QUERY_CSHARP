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

            

            // this is the groupjoin 
            // this is the groupping and joinnning 
            // at the same time
            // we will group like the same 
            // but this time we will
            // join the country name
            // we sort them based on the manufacturer 
            // so we select them first
            // it will create a hiararcical group
            // there will be a cargroup under
            // one manufacturer
            var query = from manufacturer in manufacturers
            join car in cars
            on manufacturer.Name equals car.Manufacturer
            into cargroup
            select new {
                Manufac = manufacturer,
                Cars = cargroup
            };

            // we can do the same job with groupjoin keyword
            var query2 = manufacturers.GroupJoin(cars,m =>m.Name,c =>c.Manufacturer,(m ,g)=>new {
                Manufac = m,
                Cars = g
            }).OrderBy(m =>m.Manufac.Name);



            // printting
            foreach(var group in query2){
                Console.WriteLine(group.Manufac.Name);

                foreach(var car in group.Cars.OrderByDescending(c => c.Combined).Take(2)){
                        Console.WriteLine($"\t {car.Name} : {car.Combined}");    
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
