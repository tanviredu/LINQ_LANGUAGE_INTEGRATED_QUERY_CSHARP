using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_properties_deffered_execution
{
    class Program
    {
       public static void Main(string[] args)
        {
            // linq queries and differed execution
            // make a  movie list retun Ienumerable

             IEnumerable<Movie> movies = new List<Movie>{
                    // we declare 10 different movies
                    new Movie {Title="Avenger",Rating = 9.9f,Year=2020},
                    new Movie {Title="Batman",Rating = 5.9f,Year=2008},
                    new Movie {Title="django unchained",Rating = 2.5f,Year=2000},
                    new Movie {Title="Shawsank Redumption",Rating = 10.0f,Year=1996},
                    new Movie {Title="spiderman",Rating = 9.9f,Year=2006},
                    new Movie {Title="Ironman",Rating = 6.9f,Year=2002}


            };

            // we loopthrough the movie with 
            // then we filter with both query functional and 
            // the linq query
            foreach( var movie in movies){
                System.Console.WriteLine($"Movie Name : {movie.Title,-6}");
            }

            System.Console.WriteLine("***********************");
            System.Console.WriteLine("This is a random query test");

            var query = from movie in movies
                        where movie.Rating >=5.0f &&
                        movie.Year >2002
                        select movie;

            // differed execution
            foreach (var movie in query){
                System.Console.WriteLine($"Movie : {movie.Title,-6}  Rating: {movie.Rating,-6} ");
            }

            System.Console.WriteLine("another query with functional");
            System.Console.WriteLine("************************************");
            // make this with functional query
            var query_func = movies.Where(m => (m.Rating >=5.0f)  && (m.Year >2002));

            foreach (var movie in query_func){
                System.Console.WriteLine($"Movie : {movie.Title,-6}  Rating: {movie.Rating,-6} ");
            }


            System.Console.WriteLine("THIS IS THE CUSTOM");
            System.Console.WriteLine("************************************");
            // make a custom filter
            // exactly like the where clause            
            var cu_query = movies.Filter(m => (m.Rating >=5.0f)  && (m.Year >2002));
            
            foreach (var movie in cu_query){
                System.Console.WriteLine($"Movie : {movie.Title,-6}  Rating: {movie.Rating,-6} ");
            }


            // but did the query execute in the for loop or
            // where you delare it ??
            // lets check both of it

            System.Console.WriteLine("THIS IS THE LINQ GENERIC");
            System.Console.WriteLine("************************************");
            // make a custom filter
            // exactly like the where clause            
            var cu_query2 = movies.Where(m => (m.Rating >=5.0f)  && (m.Year >2002));
            
            foreach (var movie in cu_query2){
                System.Console.WriteLine($"Movie : {movie.Title,-6}  Rating: {movie.Rating,-6} ");
            }


            // we can see that the generic class
            // immindietly return when the data matched
            // but out custom flter go throuhj all of this
            // then store then return
            // custom filter is not a deferd execution example
            // we can solve the problem using yeild 
            // statement
            // the yeild will immidieatly reurn the value
            //then come back and run the loop

            

        }
    }
}
