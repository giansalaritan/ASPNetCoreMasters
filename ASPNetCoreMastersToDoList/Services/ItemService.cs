using DomainModels;
using Repositories;
using Services.DTO;

namespace Services
{
    public class ItemService : IItemService
    {
        protected readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IEnumerable<ItemDTO> GetAll()
        {
            return _itemRepository.All()
                .Select(x => MapItem(x));
        }

        public ItemDTO Get(int itemId)
        {
            var item = _itemRepository.All()
                .Where(x => x.Id == itemId).FirstOrDefault();
            return MapItem(item);
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            var list = _itemRepository.All().ToList()
                .Where(x => x.Text.Contains(filters.Text, StringComparison.CurrentCultureIgnoreCase))
                .Select(x => MapItem(x));
            return list;
        }

        public void Add(ItemDTO itemDTO)
        {
            _itemRepository.Save(itemDTO.Map());
        }

        public void Update(ItemDTO itemDTO)
        {
            _itemRepository.Save(itemDTO.Map());
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }

        private static ItemDTO MapItem(Item? item)
        {
            return item == null ?
                new ItemDTO() :
                new ItemDTO()
                {
                    Id = item.Id,
                    Text = item.Text
                };
        }
    }
}