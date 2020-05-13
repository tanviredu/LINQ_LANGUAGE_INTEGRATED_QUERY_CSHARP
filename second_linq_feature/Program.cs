using System;
using System.Collections.Generic;

namespace second_linq_feature
{
    class Program
    {
        static void Main(string[] args)
        {
            // create two diferent list of employee
            // this list is an implement of IEnumrable <T>
            // so we can use the return type 
            // of the iEnumrable

            IEnumerable <Employee> sales = new List<Employee>(){
                new Employee {Id=1,Name="Scott"},
                new Employee {Id=2,Name="Ornob"},
                new Employee {Id=3,Name="zakaria"},
                new Employee {Id=4,Name="korim"},
                new Employee {Id=5,Name="ahmed"},
                new Employee {Id=6,Name="bobby"},
                new Employee {Id=7,Name="person1"},
                new Employee {Id=8,Name="person2"}
            };

            IEnumerable <Employee> developers = new List<Employee>(){
                new Employee {Id=3,Name="Tanvir Rahman"},
                new Employee {Id=4,Name="Tanvir Rahman ornob"},
                new Employee {Id=5,Name="Ornik"},
            };


            foreach (var person in developers){
                Console.WriteLine(person.Name);
            }

            // since this is a implementation 
            // of the Ienumrable 
            // it has a get a method called GetEnumerator()
            // this will give us  aitrable object

            // this is also a foreach statement
            // but doing in the hard way
            // this is happen behind the scene in 
            // for each loop
            var enumerator = developers.GetEnumerator();
            while(enumerator.MoveNext()){
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine($"Number of Developer : {developers.Count()}");
            Console.WriteLine($"Number of Sales Person : {sales.Count()}");
            // we can see that we can use this method 
            // in any array or list or ienuerable
            // this how the linq is written

        }
    }
}
