using DomainModels;

namespace Services.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Item Map()
        {
            return new Item
            {
                Id = Id,
                Text = Text
            };
        }
    }
}
