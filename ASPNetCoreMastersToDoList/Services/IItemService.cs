using DomainModels;
using Services.DTO;

namespace Services
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetAll();

        ItemDTO Get(int itemId);

        IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters);

        void Add(ItemDTO itemDTO, User user);

        void Update(ItemDTO itemDTO);

        void Delete(int id);
    }
}
