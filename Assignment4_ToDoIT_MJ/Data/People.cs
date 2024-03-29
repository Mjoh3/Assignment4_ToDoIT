﻿using System;

using Assignment4_ToDoIT_MJ.Model;

namespace Assignment4_ToDoIT_MJ.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];
        public int Size() { return personArray.Length; }
        public Person[] FindAll() { return personArray; }

        public Person FindById(int personId) { //in order to find the correct value I need to loop through until I find the right id
          
            for(int i=0; i<personArray.Length; i++)
            {
                if (personId == personArray[i].GetPersonId())
                {
                    return personArray[i];
                    
                }                    

            }
            return null;
        }

        public Person NewPerson(string firstName, string lastName) //as for the requirement I need to extend the arraysize, and then input new person in the last spot of the array 
        {
            int arraylength = personArray.Length;
            Array.Resize(ref personArray, (arraylength + 1));
            personArray[personArray.Length - 1] = new Person(firstName, lastName);
            return personArray[personArray.Length - 1];
        }
        public void Clear() { personArray = new Person[0]; } //creating a new empty array is the same as clearing the old.
        public void RemoveSelectedPerson(Person person)
        {//this method works exactly the same way as removeselectedtodo
            int personidx = 0;
            while (personidx < personArray.Length)
            {
                if (person.Equals(personArray[personidx]))
                {
                    break;
                }
                personidx++;
            }
            if (personidx < personArray.Length)
            {
                for (int i = personidx; i < (personArray.Length - 1); i++)
                {
                    personArray[i] = personArray[i + 1];
                }
                Array.Resize(ref personArray, (personArray.Length - 1));
            }
            else
            {
                throw new Exception("could not find the person");
            }
        }
    }
}
