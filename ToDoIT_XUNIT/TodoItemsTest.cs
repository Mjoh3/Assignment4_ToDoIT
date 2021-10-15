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
        public void CheckClearMethod() //check if clear works and the array is empty
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
            //creating people and todoitems
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");

            people.NewPerson("James", "Rown");
            people.NewPerson("Al", "Mackes");
            people.NewPerson("All", "Gold");
            people.NewPerson("Dank", "Memes");
            //assigning only two items with a person 
            todoitems.FindById(4).Assignee = people.FindById(1);
            todoitems.FindById(3).Assignee = people.FindById(2);
            //checking both the one function that takes a person as parameter and the id (int) as a function
            var a = todoitems.FindByAssignee(people.FindById(1));
            var b= todoitems.FindByAssignee(1);
            //they should match
            Assert.Equal(a, b);
        }
        [Fact]
        public void CheckUnassigned() //check for unassigned
        {
            TodoSequencer.reset();
            todoitems.Clear();

            PersonSequencer.reset();
            people.Clear();

            //creating 4 todoItems
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");
            //creating one person to people and assigning him to the last todoitem
            people.NewPerson("James", "Rown");
            todoitems.FindById(4).Assignee = people.FindById(1);
            
            //it should now be three items that are not assigned
            Assert.Equal(3, todoitems.FindUnassignedTodoItems().Length);
        }

        [Fact]
        public void RemovalSizetest() //check if the id is correct by correcting 
        {
            TodoSequencer.reset();
            todoitems.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");
            int preRemovalSize = todoitems.Size();
            todoitems.RemoveSelectedTodo(todoitems.FindAll()[0]);
            int postRemovalSize = todoitems.Size();
            Assert.True(preRemovalSize == (postRemovalSize + 1));
        }
        [Fact]
        public void Removalcheckforleftoverstest()
        { //check if the id is correct by correcting the item is still left
            PersonSequencer.reset();
            todoitems.Clear();
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Eat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Run");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Neat");
            todoitems.NewTodo(TodoSequencer.nextToDoId(), "Bun");

            int counterpre = 0;
            int counterpost = 0;
            var selectedtodo = todoitems.FindAll()[0];

            foreach (var person in todoitems.FindAll()) { if (selectedtodo == person) { counterpre++; } }
            todoitems.RemoveSelectedTodo(todoitems.FindAll()[0]);

            foreach (var person in todoitems.FindAll()) { if (selectedtodo == person) { counterpost++; } }

            Assert.True(counterpost == 0 && counterpre > 0);
        }

        [Fact]
        public void NotfindPerson()
        { //we want to know if we tried to remove someone who should not be in the array
            TodoSequencer.reset();
            todoitems.Clear();

            Assert.Throws<Exception>(() => todoitems.RemoveSelectedTodo(new Assignment4_ToDoIT_MJ.Model.Todo(TodoSequencer.nextToDoId(),"break in")));
        }
    }
}
