using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.Data.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogsContext _context;
        public CatalogRepository(CatalogsContext context)
        {
            _context = context;
        }
        public async Task<Catalog> GetByID(Guid Id)
        {
            return await _context.Catalog.Include(x => x.CatalogItem).FirstOrDefaultAsync(x => x.CatalogId == Id);
        }

        public void Delete(Guid id)
        {
            Catalog entityToDelete = _context.Catalog.Find(id);
            if(entityToDelete == null)
            {
                return;
            }
            entityToDelete.Deleted = true;
            _context.Catalog.Attach(entityToDelete);
            _context.Entry(entityToDelete).State = EntityState.Modified;       
        }
    }
}
