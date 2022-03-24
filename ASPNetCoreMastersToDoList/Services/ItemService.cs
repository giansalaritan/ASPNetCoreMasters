using DomainModels;
using Microsoft.Extensions.Logging;
using Repositories;
using Services.DTO;

namespace Services
{
    public class ItemService : IItemService
    {
        protected readonly IItemRepository _itemRepository;
        private readonly ILogger<ItemService> _logger;

        public ItemService(ILogger<ItemService> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            _logger.LogInformation("Getting All Items {RequestTime}", DateTime.Now);
            return _itemRepository.All()
                .Select(x => MapItem(x));
        }

        public ItemDTO Get(int itemId)
        {
            _logger.LogInformation("Getting Item {ItemId} : {RequestTime}", itemId, DateTime.Now);
            var item = _itemRepository.All()
                .Where(x => x.Id == itemId).FirstOrDefault();
            return MapItem(item);
        }

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filters)
        {
            _logger.LogInformation("Getting Items By Filter {Filters} : {RequestTime}", filters.Text, DateTime.Now);
            var list = _itemRepository.All().ToList()
                .Where(x => x.Text.Contains(filters.Text, StringComparison.CurrentCultureIgnoreCase))
                .Select(x => MapItem(x));
            return list;
        }

        public void Add(ItemDTO itemDTO, User user)
        {
            _logger.LogInformation("Adding Item {UserId} : {ItemName} : {RequestTime}", user.Id, itemDTO.Text, DateTime.Now);
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
            _logger.LogInformation("Updating Item {ItemId} : {RequestTime}", itemDTO.Id, DateTime.Now);
            _itemRepository.Save(itemDTO.Map());
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Deleting Item {ItemId} : {RequestTime}", id, DateTime.Now);
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