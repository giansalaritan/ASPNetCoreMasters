using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}