using Services.DTO;

namespace ASPNetCoreMastersToDoList.BindingModels
{
    public class ItemFilterBindingModel
    {
        public string Text { get; set; }
        public ItemByFilterDTO Map()
        {
            return new ItemByFilterDTO
            {
                Text = Text
            };
        }
    }
}
