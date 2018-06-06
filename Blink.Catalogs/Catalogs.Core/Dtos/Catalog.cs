using System;
using System.Collections.Generic;

namespace Catalogs.Core.Dtos
{
    public class CatalogDto
    {
        public Guid CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }
        public ICollection<CatalogItemDto> CatalogItem { get; set; }
    }
}
