using DomainModels;

namespace Services.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Guid CreatedBy { get; set; } 
        public DateTime DateCreated { get; set; }
        public Item Map()
        {
            return new Item
            {
                Id = Id,
                Text = Text,
                CreatedBy = CreatedBy,
                DateCreated = DateCreated
            };
        }
    }
}
