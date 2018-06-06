using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;

namespace Catalogs.Core.UnitsOfWork
{
    public interface ICatalogUnit : IUnitOfWork
    {
        ICatalogRepository CatalogRepository { get; }
        IGenericRepository<Catalog> CatalogABCRepository { get; }
    }
}
