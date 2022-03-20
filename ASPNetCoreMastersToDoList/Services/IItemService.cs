using Services.DTO;

namespace Services
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAll();

        ItemDTO Get(int itemId);

        IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);

        void Add(ItemDTO itemDTO);

        void Update(ItemDTO itemDTO);

        void Delete(int itemId);
    }
}
