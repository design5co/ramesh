using static Testlet.Service.Utilities.Enum;
using Testlet.Service.Utilities;

namespace Testlet.Service.Services
{
    public class TestletService 
    {
        public List<Item> GetOrderedItem()
        {
            var randomizedItems = RandomizeItems();

            // Move the first two pretest items to the beginning
            var pretestItems = randomizedItems.Where(item => item.Type == ItemType.Pretest).Take(2).ToList();
            var pretestItemIds = pretestItems.Select(x => x.ItemId).ToList();
            randomizedItems.RemoveAll(item => pretestItemIds.Contains(item.ItemId));
            randomizedItems.InsertRange(0, pretestItems);
            return randomizedItems;
        }
        private List<Item> RandomizeItems()
        {
            var lstItem = GetItems();
            var random = new Random();
            return lstItem.OrderBy(item => random.Next()).ToList();
        }

        public List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item {ItemId =1,Type = ItemType.Pretest },
                new Item {ItemId =2,Type = ItemType.Pretest },
                new Item {ItemId =3,Type = ItemType.Pretest },
                new Item {ItemId =4,Type = ItemType.Pretest },
                new Item {ItemId =5,Type = ItemType.Operational },
                new Item {ItemId =6,Type = ItemType.Operational },
                new Item {ItemId =7,Type = ItemType.Operational },
                new Item {ItemId =8,Type = ItemType.Operational },
                new Item {ItemId =9,Type = ItemType.Operational },
                new Item {ItemId =10,Type = ItemType.Operational }
            };
        }
    }
}
