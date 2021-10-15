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
        public Todo(int todoId,string description, bool done=false, Person assignee=null) //at this stage only todoID and desctption should be set.
        {
            this.todoId = todoId;
            this.Description = description;
            this.Assignee = assignee;
            this.Done = done;
        }
        
        public int GetTodoID() { return todoId; }
        public String Description { get => description; set => description=value; } //there were no rules set at this stage
        public bool Done { get => done; set => done = value; }
        public Person Assignee { get => assignee; set => assignee = value; }

    }
}
