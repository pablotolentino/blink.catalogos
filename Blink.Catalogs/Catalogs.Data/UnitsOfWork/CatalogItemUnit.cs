using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;
using Catalogs.Core.UnitsOfWork;
using Catalogs.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Data.UnitsOfWork
{
    public class CatalogItemUnit : ICatalogItemUnit
    {
        private readonly CatalogsContext _context;
        public ICatalogItemRepository CatalogItemRepository { get; private set; }
        public IGenericRepository<CatalogItem> CatalogItemABCRepository { get; private set; }

        public CatalogItemUnit(CatalogsContext context)
        {
            _context = context;
            this.CatalogItemRepository = new CatalogItemRepository(context);
            this.CatalogItemABCRepository = new GenericRepository<CatalogItem>(context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
