using System;
using System.Collections.Generic;

namespace Catalogs.Core.Entities
{
    public partial class Catalog
    {
        public Catalog()
        {
            CatalogItem = new HashSet<CatalogItem>();
        }

        public Guid CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<CatalogItem> CatalogItem { get; set; }
    }
}
