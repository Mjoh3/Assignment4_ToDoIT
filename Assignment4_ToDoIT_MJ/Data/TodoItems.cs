using System;

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

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] donelist = new Todo[0];
            int listsize = donelist.Length;
            foreach(var p in todoArray)
            {
                if (doneStatus == p.Done) {
                    listsize = donelist.Length;
                    Array.Resize(ref donelist, listsize + 1);
                    donelist[listsize] = p;
                }
            }
            return donelist;
        }
        public Todo[] FindByAssignee(int personId) //check first if the 
        {
            //Person assignee = this.assi
            Todo[] donelist = new Todo[0];
            int listsize = donelist.Length;
            foreach (var p in todoArray)
            {
                if (p.Assignee != null)
                {
                    if (p.Assignee.GetPersonId() == personId)
                    {
                        listsize = donelist.Length;
                        Array.Resize(ref donelist, listsize + 1);
                        donelist[listsize] = p;
                    }
                }
            }
            return donelist;
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] donelist = new Todo[0];
            int listsize = donelist.Length;
            foreach (var p in todoArray)
            {
                if (p.Assignee==assignee)
                {
                    listsize = donelist.Length;
                    Array.Resize(ref donelist, listsize + 1);
                    donelist[listsize] = p;
                }
            }
            return donelist;
        }
        public Todo[] FindUnassignedTodoItems() //similar to last method but only adds if the assignee is null
        {
            Todo[] donelist = new Todo[0];
            int listsize = donelist.Length;
            foreach (var p in todoArray)
            {
                if (p.Assignee == null)
                {
                    listsize = donelist.Length;
                    Array.Resize(ref donelist, listsize + 1);
                    donelist[listsize] = p;
                }
            }
            return donelist;
        }
    }
}
