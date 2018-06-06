using Catalogs.Core.Entities;
using Catalogs.Core.Repositories;
using Catalogs.Core.UnitsOfWork;
using Catalogs.Data.Repositories;
using System.Threading.Tasks;

namespace Catalogs.Data.UnitsOfWork
{
    public class CatalogUnit : ICatalogUnit
    {

        private readonly CatalogsContext _context;
        public ICatalogRepository CatalogRepository { get; private set; }
        public IGenericRepository<Catalog> CatalogABCRepository { get; private set; }

        public CatalogUnit(CatalogsContext context)
        {
            _context = context;
            this.CatalogRepository = new CatalogRepository(context);
            this.CatalogABCRepository = new GenericRepository<Catalog>(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public  async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
