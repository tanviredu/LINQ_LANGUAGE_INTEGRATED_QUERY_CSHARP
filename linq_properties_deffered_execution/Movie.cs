using System;

namespace linq_properties_deffered_execution{


    // cjhanging the getter and the setter to find out
    // which on is how affeted

    public class Movie{
        public string Title {get;set;}
        public float Rating {get;set;}
        int _year;
        public int Year{
            get{
                System.Console.WriteLine($"{_year} is called");
                return _year;
            }
            set{
                _year = value;
            }
        }

    }

}