using Catalogs.Core.Entities;
using System;

namespace Catalogs.Core.Repositories
{
    public interface ICatalogItemRepository
    {       
        void Delete(Guid id);
    }
}
