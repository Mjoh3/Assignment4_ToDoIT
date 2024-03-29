using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Model;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
    public class PersonTests
    {
        [Fact]
        public void RegularPerson() //just seeing if it gets what it it is suppose to get (Hugo Boss)
        {
            string firstname = "Hugo";
            string lastname = "Boss";
            Person testperson=new Assignment4_ToDoIT_MJ.Model.Person(firstname,lastname);
            Assert.Equal(firstname, testperson.FirstName);
            Assert.Equal(lastname, testperson.LastName);
        }
        [Theory]
        [InlineData("Leonard",null)]
        [InlineData(null,"Sword")]
        [InlineData(null,null)]
        public void NullFieldInPerson(string firstname,string lastname) //because we have limits on the name fields we need to test that it throws an error
        {           
            Assert.Throws<NullReferenceException>(() => new Person(firstname,lastname));//in this case we check null
        }
        [Theory]
        [InlineData("Leonard", "")]
        [InlineData("", "Sword")]
        [InlineData("", "")]
        public void EmptyFieldInPerson(string firstname, string lastname) //because we have limits on the name fields we need to test that it throws an error
        {
            Assert.Throws<ArgumentException>(() => new Person(firstname, lastname));//in this case we check for empty fields
        }
        
        
    }
}
