using System;
using System.Collections.Generic;

namespace Catalogs.Core.Entities
{
    public partial class CatalogItem
    {
        public Guid CatalogItemId { get; set; }
        public Guid CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public bool? Deleted { get; set; }

        public Catalog Catalog { get; set; }
    }
}
