using Services.DTO;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class ItemUpdateBindingModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
        public ItemDTO Map()
        {
            return new ItemDTO
            {
                Id = Id,
                Text = Text
            };
        }
    }
}
