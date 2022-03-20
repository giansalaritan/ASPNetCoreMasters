using DomainModels;

namespace Repositories
{
    public interface IItemRepository
    {
        IQueryable<Item> All();
        void Save(Item item);
        void Delete(int itemId);
    }
}
