using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Model;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
    public class todoTests
    {
        
        private Todo testTodo = new Todo(1, "Read chapter 1");
        [Fact]
        public void CheckDescriptionAndIDvalues() 
        {
            Assert.True(testTodo.GetTodoID() == 1 && testTodo.Description == "Read chapter 1");
        }
        
    }
}
