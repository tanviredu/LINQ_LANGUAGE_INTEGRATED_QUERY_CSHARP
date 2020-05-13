using System;
using System.Collections.Generic;

namespace linq_properties_deffered_execution{


    // this is where we make a extension method
    // to understand how the where clause works
    // and also the lazy execution
    // and instant execution

    public static class Mylinq{


        // we make generic function
        // take Ienumrable<T> 
        // and a func function that will return a boolean 
        // helps how to make decision
        // and return Ienumrable<T>
        // in the func the 
        // Func<T,bool>
        // T is input and boo, is output



        /// need to uder stand we take  a Ienumrable and we return the 
        // ienumrable the func<T,bool> mast be passed
        // this will also ttake the movie type but it will
        // return a bool that if it is going to decide what to take and 
        // what to reject
        // this will peorcess the lamba expression

        // 



        // now this function is the exact 
        // representation of the where extension method
        public static IEnumerable<T> Filter <T>(this IEnumerable<T> source,Func<T,bool> predicate ){

            var result = new List<T>(); // empty list

            foreach (var item in source){
                
                if(predicate(item)){
                    yield return item;
                }
            }

            

        }






    }

}