using System;
using Xunit;

namespace ConsoleApp.UnitTests
{
    public class EntryBuilderMust
    {
        [Fact]
        public void ReturnNullEntry_WhenMessageWithoutTextIsSpecified()
        {
            var entry = new Entry.Builder().AsMessage().Build();
            Assert.IsType<NullEntry>(entry);
        }

        [Fact]
        public void ThrowException_WhenNoneOfMessageWarningErrorIsSpecifiedInMethod()
        {
            var exception = Assert.Throws<Exception>(() => new Entry.Builder().WithText("test").Build());
            Assert.Equal(Logger.MUST_SPECIFY_MESSAGE_WARNING_ERROR, exception.Message);
        }
    }
}