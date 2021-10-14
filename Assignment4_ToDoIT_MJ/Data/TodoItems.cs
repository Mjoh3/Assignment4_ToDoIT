using System;
using System.Collections.Generic;
using System.Text;
using Assignment4_ToDoIT_MJ.Model;
namespace Assignment4_ToDoIT_MJ.Data
{
    public class TodoItems
    {
        private static Todo[] todoArray = new Todo[0];
        public int Size() { return todoArray.Length; }
        public Todo[] FindAll() { return todoArray; }

        public Todo FindById(int todoId)
        { //in order to find the correct value I need to loop through until I find the right id

            for (int i = 0; i < todoArray.Length; i++)
            {
                if (todoId == todoArray[i].GetTodoID())
                {
                    return todoArray[i];

                }

            }
            return null;
        }

        public Todo NewTodo(int id, string description) //as for the requirement I need to extend the arraysize, and then input new todo in the last spot of the array 
        {
            int arraylength = todoArray.Length;
            Array.Resize(ref todoArray, (arraylength + 1));
            todoArray[todoArray.Length - 1] = new Todo(id, description);
            return todoArray[todoArray.Length - 1];
        }
        public void Clear() { todoArray = new Todo[0]; } //creating a new empty array is the same as clearing the 
    }
}
