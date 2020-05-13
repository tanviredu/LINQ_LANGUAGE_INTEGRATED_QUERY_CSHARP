using System;

namespace second_linq_feature{

    public class Patient{

        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}

        private string _fullname;

        public string FullName{
            get{
                return _fullname = FirstName +" "+ LastName;
            }
         }

         public string Address {get;set;}

    }

}