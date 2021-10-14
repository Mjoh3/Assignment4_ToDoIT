using System;

namespace Assignment4_ToDoIT_MJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.People testpeople = new Data.People();
            Data.PersonSequencer.reset();
            testpeople.Clear();
            testpeople.NewPerson("A", "1");
            testpeople.NewPerson("B", "2");
            testpeople.NewPerson("D", "4");
            testpeople.NewPerson("Q", "7");
            foreach (Model.Person p in testpeople.FindAll())
            {
                Console.WriteLine(p.FirstName + p.LastName + " " + p.GetPersonId());
            }
        }
    }
}
