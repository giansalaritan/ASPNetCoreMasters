using DomainModels;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        protected readonly DataDbContext _dataContext;

        public ItemRepository(DataDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Item> All()
        {
            return _dataContext.Items;
        }

        public void Delete(int itemId)
        {
            var item = _dataContext.Items.FirstOrDefault(x => x.Id == itemId);
            if (item != null)
            {
                _dataContext.Items.Remove(item);
                _dataContext.SaveChanges();
            }
        }

        public void Save(Item item)
        {
            if (item.Id > 0)
            {
                _dataContext.Items.Update(item);
            }
            else
            {
                _dataContext.Items.Add(item);
            }
            _dataContext.SaveChanges();
        }
    }
}
