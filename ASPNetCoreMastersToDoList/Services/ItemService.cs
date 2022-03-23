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

        public void Add(ItemDTO itemDTO, User user)
        {
            try
            {
                itemDTO.CreatedBy = Guid.Parse(user.Id);
                itemDTO.DateCreated = DateTime.UtcNow;
                _itemRepository.Save(itemDTO.Map());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
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
                    Text = item.Text,
                    CreatedBy = item.CreatedBy,
                    DateCreated = item.DateCreated
                };
        }
    }
}