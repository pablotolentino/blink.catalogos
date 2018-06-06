using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;

namespace Catalogs.Core.UnitsOfWork
{
    public interface ICatalogItemUnit: IUnitOfWork
    {
        ICatalogItemRepository CatalogItemRepository { get; }
        IGenericRepository<CatalogItem> CatalogItemABCRepository { get; }
    }
}
