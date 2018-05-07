using Game;
using Xunit;

namespace BreakoutTests
{
    public class Class1Tests
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Class1.Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Class1.Add(2, 2));
        }

    }
}
