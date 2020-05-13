// now we are using linq 
// functional to filter data
// and we make another complecaed class
// to do that

using System.Linq;
using System;
using System.Collections.Generic;

namespace second_linq_feature
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IEnumerable<Patient> patients= new List<Patient>(){
                new Patient{Id = 1,FirstName="Tanvir",LastName="Rahman",Address="ABC"},
                new Patient{Id = 2,FirstName="zakaria",LastName="bijoy",Address="DEF"},
                new Patient{Id = 3,FirstName="mridul",LastName="hossain",Address="GEH"},
                new Patient{Id = 4,FirstName="Tonmoy",LastName="Rahman",Address="ABC123"},
                new Patient{Id = 5,FirstName="hasnat",LastName="gazi",Address="ERT34"},
                new Patient{Id = 6,FirstName="rabi",LastName="rahman",Address="CDA23"}
            };


            // applying  a loop to see if it is loaded
            foreach(var patient in patients){
                System.Console.WriteLine($"Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }            

            // make the filter 

            System.Console.WriteLine("First filter based on the lastname");
            System.Console.WriteLine("*********************************************");
            foreach (var patient in patients.Where(p => p.LastName =="Rahman" )){
                System.Console.WriteLine($"Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }

            
             // make the filter 

            System.Console.WriteLine("First filter based on the lastname oderby address in descending order");
            System.Console.WriteLine("*********************************************");
            foreach (var patient in patients.Where(p => p.LastName =="Rahman").OrderByDescending(p => p.Address)){
                System.Console.WriteLine($"Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }

            
             // make the filter 

            System.Console.WriteLine("Find the person who have address is CDA23");
            System.Console.WriteLine("*********************************************");
            foreach (var patient in patients.Where(p => p.Address == "CDA23")){
                System.Console.WriteLine($"Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }

            System.Console.WriteLine("another random query");
            System.Console.WriteLine("*********************************************");
            
            var query = from patient in patients
                            orderby patient.Id descending, patient.FullName descending
                            select patient;

            foreach(var patient in query){
                System.Console.WriteLine($"Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }


            System.Console.WriteLine("another random query");
            System.Console.WriteLine("*********************************************");
            
            var query2 = from patient in patients
                            orderby patient.Id descending
                            select patient;

            foreach(var patient in query2){
                System.Console.WriteLine($"ID {patient.Id,-5} Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }

            System.Console.WriteLine("another random query");
            System.Console.WriteLine("*********************************************");
            
            var query3 = from patient in patients
                            where patient.FirstName.StartsWith("T")
                            orderby patient.Id
                            select patient;

            foreach(var patient in query3){
                System.Console.WriteLine($"ID {patient.Id,-5} Patient FullName : {patient.FullName,-20} Address : {patient.Address} ");
            }


            /// make anohrt array and apply query with
            /// function and both the functional
            /// and the query type

            string[] cities = {"Dhaka","Chittagong","barisal","Khulna","new york","kolkata","bomby"};

            var query4 = from city in cities
                            where city.StartsWith("D") && city.Length <15
                            orderby city 
                            select city;


            System.Console.WriteLine("another random query");
            System.Console.WriteLine("*********************************************");
            
            foreach (var city in query4){
                System.Console.WriteLine($"City Name : {city,-3}");
            }
            System.Console.WriteLine("another random query");
            System.Console.WriteLine("*********************************************");
            /// doing the same thing with method syntax
            foreach(var city in cities.Where(c => c.StartsWith('D')).OrderBy(c => c)){
                System.Console.WriteLine($"City Name : {city,-3}");
            }



        }
    }
}
