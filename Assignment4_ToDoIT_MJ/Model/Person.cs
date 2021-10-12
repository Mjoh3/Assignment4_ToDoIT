using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_ToDoIT_MJ.Model
{
    public class Person
    {
        
        private readonly int personId; 
        private string firstName;
        private string lastName;

        public Person(string firstName,string lastName)
        {
            
            FirstName = firstName; //using the property field in order to prevent empty fields or null values
            LastName = lastName; //-**-
        }
        
        public string FirstName //Access firstName in order to modify it outside of the class and make it follow certain rules in order what to set
        {
            get { return firstName; }
            set {
                if (value.Length < 1) //FirstName does not allow empty fields
                    throw new ArgumentException("FirstName must be a valid string longer than 0 characters");
                else if (value == null) //FirstName does not allow null values
                    throw new ArgumentNullException("FirstName can not be null");
                else 
                    firstName = value;
            }
        }
       
        public string LastName //Access lastName in order to modify it outside of the class and make it follow certain rules in order what to set
        {
            get { return lastName; }
            set
            {
                if (value.Length < 1) //LastName does not allow empty fields
                    throw new ArgumentException("LastName must be a valid string longer than 0 characters");
                else if (value == null) //LastName does not allow null values
                    throw new NullReferenceException("Value must not be null");
                else
                    lastName = value;
            }
        }
    }
}
