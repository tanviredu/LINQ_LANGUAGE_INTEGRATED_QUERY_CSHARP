using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace cars_project
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

            // run a loop through it and 
            // see if it works

            // add further query to query 
            var query3 = cars.OrderByDescending(c => c.Combined)
            .ThenBy(c => c.Name);

            // this will put the most efficieant car at the top
            // we need a secondary sort for this
            // you can add another sort method
            // with then
            var same_query = from car in cars
                            orderby car.Combined descending,car.Name ascending
                            select car;
            // this is the same query 
            // for the same result;

            // we an do it with the same with query

            foreach (var car in query3.Take(10)){ // take the top 10 value
                System.Console.WriteLine($"{car.Name,-5}  Effiency :{car.Combined,-10}");
            }

            // foreach(var car in cars){
            //     System.Console.WriteLine(car.Name);
            // }


        }

        // return a list of cars
        private static List<Car> ProcessFile(string path)
        {
            // we need to read the file
            // it will return  a ienumrable of string array
           var query1 =  File.ReadAllLines(path)
            .Skip(1) // for the label
            .Where(row => row.Length >1)   // do not take an empty row
            .Select(Car.ParseFromCsv).ToList();
            return query1;
        }

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
