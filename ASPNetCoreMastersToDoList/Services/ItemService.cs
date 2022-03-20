using DomainModels;
using Services.DTO;

namespace Services
{
    public class ItemService
    {
        private static List<Item> Items = new List<Item>();

        public static List<Item> GetAll()
        {
            return Items;
        }

        public static Item Get(int itemId)
        {
            var item = new Item();
            item = Items.Find(x => x.Id == itemId);
            return item ?? new Item();
        }

        public static List<Item> GetByFilter(Dictionary<string, string> filters)
        {
            return new List<Item>();
        }

        public static bool Save(ItemDTO item)
        {
            int max = Items.Max(x => x.Id);
            Items.Add(new Item()
            {
                Id = max ++,
                Text = item.Text
            });

            return true;
        }

        public static bool Update(ItemDTO item)
        {
            return true;
        }

        public static bool Delete(int itemId)
        {
            return true;
        }
    }
}