using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
    public class PeopleTests
    {
        private People testpeople = new People();
        [Fact]
        public void PeopleClearTest() //clear function must return an empty 
        {
            testpeople.NewPerson("Kalle", "Anka");
            testpeople.Clear();
            Assert.True(0 == testpeople.FindAll().Length);
        }
        [Fact]
        public void AddPeopleTest() //to check if it added twice I need to add 2 items and then chech the array
        {
            testpeople.Clear();
            testpeople.NewPerson("Kalle", "Anka");
            testpeople.NewPerson("Musse", "Pigg");
            Assert.True(2 == testpeople.FindAll().Length);
        }
        [Theory]

        [InlineData(1)]
        [InlineData(5)]
        public void FindIDtest(int expectedID) //check if the id is correct by correcting 
        {
            PersonSequencer.reset();
            testpeople.Clear();
            testpeople.NewPerson("Algot", "Algotsson");//id1
            testpeople.NewPerson("Beata", "Becker");//id2
            testpeople.NewPerson("Diana", "Dracovic");
            testpeople.NewPerson("Emil", "Enemark");
            testpeople.NewPerson("Nelly", "Nelson");//id5
            Assert.Equal(expectedID, testpeople.FindById(expectedID).GetPersonId());
        }

        [Fact]
        public void FindIDNULL() //my function is testing for null that is why I am testing an ID of 1000 to see if it returns null
        {
            Assert.Throws<NullReferenceException>(() => testpeople.FindById(1000).GetPersonId());
        }
        [Fact]
        public void RemovalSizetest() //check if the id is correct by correcting 
        {
            PersonSequencer.reset();
            testpeople.Clear();
            testpeople.NewPerson("Algot", "Algotsson");//id1
            testpeople.NewPerson("Beata", "Becker");//id2
            testpeople.NewPerson("Diana", "Dracovic");
            testpeople.NewPerson("Emil", "Enemark");
            testpeople.NewPerson("Nelly", "Nelson");//id5
            int preRemovalSize = testpeople.Size();
            testpeople.RemoveSelectedPerson(testpeople.FindAll()[0]);
            int postRemovalSize = testpeople.Size();
            Assert.True(preRemovalSize == (postRemovalSize + 1));
        }
        [Fact]
        public void Removalcheckforleftoverstest()
        { //check if the id is correct by correcting the item is still left
            PersonSequencer.reset();
            testpeople.Clear();
            testpeople.NewPerson("Algot", "Algotsson");//id1
            testpeople.NewPerson("Beata", "Becker");//id2
            testpeople.NewPerson("Diana", "Dracovic");
            testpeople.NewPerson("Emil", "Enemark");
            testpeople.NewPerson("Nelly", "Nelson");//id5

            int counterpre = 0;
            int counterpost = 0;
            var selectedperson = testpeople.FindAll()[0];

            foreach (var person in testpeople.FindAll()) { if (selectedperson == person) { counterpre++; } }
            testpeople.RemoveSelectedPerson(testpeople.FindAll()[0]);

            foreach (var person in testpeople.FindAll()) { if (selectedperson == person) { counterpost++; } }

            Assert.True(counterpost == 0 && counterpre > 0);
        }

        [Fact]
        public void NotfindPerson()
        {
            PersonSequencer.reset();
            testpeople.Clear();
            testpeople.NewPerson("Algot", "Algotsson");//id1
            testpeople.NewPerson("Beata", "Becker");//id2

            Assert.Throws<Exception>(() => testpeople.RemoveSelectedPerson(new Assignment4_ToDoIT_MJ.Model.Person("Outside", "Intruder")));
        }



    }
}
