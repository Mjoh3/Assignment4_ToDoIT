using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
    public class ToDoSequencerTests
    {

        [Fact]
        public void ResetTodoSequencerTest() //this should now be 0
        {
            TodoSequencer.reset();
            Assert.Equal(0, TodoSequencer.getToDoId());
        }
        [Fact]
        public void IncrementTodoSequencerTest() //test if personId is incremented
        {
            int previous = TodoSequencer.getToDoId();
            Assert.Equal((previous + 1), TodoSequencer.nextToDoId());
        }
        
       
    }
}
