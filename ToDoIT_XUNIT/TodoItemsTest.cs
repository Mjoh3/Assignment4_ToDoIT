using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
    public class TodoItemsTest
    {
        TodoItems todoitems = new TodoItems();
        [Fact]
        public void CheckClearMethod() //check if clear works
        {
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Find me");
            todoitems.Clear();
            Assert.True(0 == todoitems.FindAll().Length);
        }
        [Fact]
        public void Addfuctionworks() //similar to the method that checks length in people tests
        {
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            Assert.True(2 == todoitems.FindAll().Length);
        }
        [Fact]
        public void FindIDworks() //similar to the method that checks id in people tests
        {
            TodoSequencer.reset();
            todoitems.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");
            Assert.Equal(3, todoitems.FindById(3).GetTodoID());
            
        }

    }
}
