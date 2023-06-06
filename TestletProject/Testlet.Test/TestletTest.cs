using Testlet.Service.Services;
using static Testlet.Service.Utilities.Enum;

namespace Testlet.Test
{
    public class TestletTest
    {
        [Fact]
        public void RandomizeItems_Should_Return_Correct_Order()
        {
            var items = new TestletService().GetOrderedItem();
            // Assert
            Assert.Equal(10, items.Count);
            Assert.Equal(2, items.Take(2).Count(i => i.Type == ItemType.Pretest));
            Assert.Equal(8, items.Skip(2).Count(i => i.Type == ItemType.Pretest || i.Type == ItemType.Operational));
        }
    }
}