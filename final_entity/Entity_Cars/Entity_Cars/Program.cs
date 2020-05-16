using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Entity_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //var cars = ProcessFilequery("fuel.csv");
            //var manufacturers = ProcessFilesecond("manufacturers.csv");

           
            string dbName = "CarDB.db";
            if (File.Exists(dbName)){
                File.Delete(dbName);
            }
            DeleteIfCreated();
            InsertData();
            QueryData();
   

        }

        private static void DeleteIfCreated()
        {
            string dbName = "CarDB.db";
            if (File.Exists(dbName)){
                File.Delete(dbName);
            }
        }

        private static void QueryData()
        {
            var db = new CarDb();

            //settig a query

            var query = from car in db.Cars
                        orderby car.Combined descending,car.Name ascending
                        select car;

            foreach(var car in query.Take(3)){
                Console.WriteLine($"{car.Name} has eff {car.Combined}");
            }
        }

        private static void InsertData()
        {
            var cars = ProcessFilequery("fuel.csv");
            
            using (var carDb = new CarDb()){
                carDb.Database.EnsureCreated();
                if(!carDb.Cars.Any()){

                    foreach (var car in cars){
                        carDb.Cars.Add(car);
                        //Console.WriteLine("added");
                    }
                    carDb.SaveChanges();
                    Console.WriteLine("info Saved");

                }
            }
           

        }

        private static List<Manufacturer> ProcessFilesecond(string path)
        {
            var query3 = File.ReadAllLines(path).Where(l => l.Length > 1)
                            .Select(l => {
                                var data = l.Split(",");
                                return new Manufacturer
                                {
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

        private static List<Car> ProcessFilequery(string path)
        {
            var query2 = from row in File.ReadAllLines(path).Skip(1)
                         where row.Length > 1
                         select Utility.ParseFromCsv(row);

            return query2.ToList();
        }


    }
}
