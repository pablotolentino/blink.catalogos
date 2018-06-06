using Catalogs.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Catalogs.Core.Repositories
{
    public interface ICatalogRepository
    {
        Task<Catalog> GetByID(Guid Id);
        void Delete(Guid id);
    }
}
