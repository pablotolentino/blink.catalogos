using System;
using System.Collections.Generic;

namespace Catalogs.Core.Dtos
{
    public  class CatalogItemDto
    {
        public Guid CatalogItemId { get; set; }
        public Guid CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public bool? Deleted { get; set; }
      //  public CatalogDto Catalog { get; set; }
    }
}
