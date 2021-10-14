using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_ToDoIT_MJ.Model
{
    public class Todo
    {
        private string description;
        private readonly int todoId;
        private bool done;
        private Person assignee;
        public Todo(int todoId,string description) //at this stage only todoID and desctption should be set.
        {
            this.todoId = todoId;
            this.Description = description;
            
        }
        public int GetTodoID() { return todoId; }
        public String Description { get => description; set => description=value; } //there were no rules set at this stage
    }
}
