using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
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
        [Fact]
        public void TodoSequencerIs1() //PersonId should be 1 because I incremented once
        {
            Assert.Equal(1, TodoSequencer.getToDoId());
        }
    }
}
