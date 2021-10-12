using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_ToDoIT_MJ.Data
{
    public class PersonSequencer
    {
        private static int personId;
        public static int getPersonId() { return personId; }
        public static int nextPersonId() { personId++; return personId; }
        public static void reset() { personId = 0; }
    }
}
