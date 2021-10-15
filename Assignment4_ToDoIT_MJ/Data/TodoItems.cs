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
        public void Clear() { todoArray = new Todo[0]; } //creating a new empty array is the same as clearing it

        public Todo[] FindByDoneStatus(bool doneStatus) //to create an array with elements with done as their status 
        {                                               //I need to see if the items are done and ajust the array accordingly
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
        public Todo[] FindByAssignee(int personId) //similar to findbystatus
        {
            
            Todo[] donelist = new Todo[0];
            int listsize = donelist.Length;
            foreach (var p in todoArray)
            {
                if (p.Assignee != null)//but I need to check if p.assigne!= null, in order to avoid checking null values for assignee that the program does not like
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
        public Todo[] FindByAssignee(Person assignee) //same as the other one but easier since I dont need to check for null values
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
        public void RemoveSelectedTodo(Todo todo)
        {
            int todoidx = 0; //first i need to find the index of the item that equals the parameter value
            while (todoidx < todoArray.Length)
            {
                if (todo.Equals(todoArray[todoidx]))
                {
                    break;
                }
                todoidx++;
            }//I need to move the other items after the selected item I remove and so I have the other ones in place before I resize
            if (todoidx < todoArray.Length)
            {
                for (int i = todoidx; i < (todoArray.Length - 1); i++)
                {
                    todoArray[i] = todoArray[i + 1];
                }
                Array.Resize(ref todoArray, (todoArray.Length - 1));
            }
            else
            {//if it didnt find anything, the indexcount should exeed the number of items and throw an exception
                throw new Exception("could not find the person");
            }
        }
    }
}
