
using System;
using System.Collections.Generic;
namespace second_linq_feature{

    // now we will make extension method
    // that will appear as a method 
    // of any object
    // this is the power of extension method
    // its important to understand becayse
    // the linq is made with the extension method
    // thats why we can use it inn
    // any collection list,iEnumrable,array etc

    /// class have to be static
    /// the method have to be static
    /// the parameter has to be start with "this" keyword

    public static class MyLinq{

        /// it will take a IEnumrable<T>
        /// and the method will be Count<T> because
        /// its a generic method and can count any type
        public static int Count<T>(this IEnumerable<T> sequence){

            int count = 0;
            foreach (var item in sequence)
            {
                count++;
            }
            return count;

        }
    }

}