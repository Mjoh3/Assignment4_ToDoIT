using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
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
            TodoSequencer.reset();
            todoitems.Clear();
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
        
        [Fact]
        public void FindByBoolworks() //similar to the method that checks id in people tests
        {
            TodoSequencer.reset();
            todoitems.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");
            todoitems.FindById(3).Done = true;
            Assert.Equal(1, todoitems.FindByDoneStatus(true).Length);
        }
        People people = new People();
        [Fact]
        public void FindByAssigneeworks() //testing both versions of the findbyassigne.
        {
            TodoSequencer.reset();
            todoitems.Clear();

            PersonSequencer.reset();
            people.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");

            people.NewPerson("James", "Rown");
            people.NewPerson("Al", "Mackes");
            people.NewPerson("All", "Gold");
            people.NewPerson("Dank", "Memes");

            todoitems.FindById(4).Assignee = people.FindById(1);
            todoitems.FindById(3).Assignee = people.FindById(2);

            var a = todoitems.FindByAssignee(people.FindById(1));
            var b= todoitems.FindByAssignee(1);
            Assert.Equal(a, b);
        }
        [Fact]
        public void CheckUnassigned()
        {
            TodoSequencer.reset();
            todoitems.Clear();

            PersonSequencer.reset();
            people.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");

            people.NewPerson("James", "Rown");
            

            todoitems.FindById(4).Assignee = people.FindById(1);
            

            var a = todoitems.FindByAssignee(people.FindById(1));
            var b= todoitems.FindByAssignee(1);
            Assert.Equal(3, todoitems.FindUnassignedTodoItems().Length);
        }
    }
}
