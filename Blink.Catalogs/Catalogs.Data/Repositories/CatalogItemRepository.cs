using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogs.Data.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogsContext _context;
        public CatalogItemRepository(CatalogsContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            CatalogItem catalogItem = _context.CatalogItem.Find(id);
            if(catalogItem == null)
            {
                return;
            }
            catalogItem.Deleted = true;
            _context.CatalogItem.Attach(catalogItem);
            _context.Entry(catalogItem).State = EntityState.Modified;
        }

    }
}
