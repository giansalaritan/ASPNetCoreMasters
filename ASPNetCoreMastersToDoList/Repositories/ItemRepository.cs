using DomainModels;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        protected readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            return _dataContext.Items.AsQueryable();
        }

        public void Delete(int itemId)
        {
        }

        public void Save(Item item)
        {
        }
    }
}
