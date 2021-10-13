using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_ToDoIT_MJ.Data
{
    public class TodoSequencer
    {
        private static int toDoId;
        public static int getToDoId() { return toDoId; }
        public static int nextToDoId() { toDoId++; return toDoId; }
        public static void reset() { toDoId = 0; }
    }
}
