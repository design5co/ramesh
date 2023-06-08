using Testlet.Service.Services;
using static Testlet.Service.Utilities.Enum;

namespace Testlet.Test
{
    public class TestletTest
    {
        [Fact]
        public void RandomizeItems_Should_Return_Correct_Order()
        {
            var testletService = new TestletService();

            var orderedItems = testletService.GetOrderedItem();

            // Assert
            Assert.Equal(10, orderedItems.Count);
            Assert.Equal(2, orderedItems.Take(2).Count(i => i.Type == ItemType.Pretest));
            Assert.Equal(8, orderedItems.Skip(2).Count(i => i.Type == ItemType.Pretest || i.Type == ItemType.Operational));

            Assert.NotEqual(testletService.GetItems(), orderedItems);
        }
    }
}
