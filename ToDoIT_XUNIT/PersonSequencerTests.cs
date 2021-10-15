using System;
using Xunit;
using Assignment4_ToDoIT_MJ.Data;

namespace ToDoIT_XUNIT
{
    [Collection("Sequential")]
    public class PersonSequencerTests
    {
        [Fact]
        public void ResetPersonSequencerTest() //this should now be 0
        {
            PersonSequencer.reset();
            Assert.Equal(0, PersonSequencer.getPersonId());
        }
        [Fact]
        public void IncrementPersonSequencerTest() //test if personId is incremented
        {
            int previous = PersonSequencer.getPersonId();
            Assert.Equal((previous + 1), PersonSequencer.nextPersonId());
        }
        
        
    }
}
