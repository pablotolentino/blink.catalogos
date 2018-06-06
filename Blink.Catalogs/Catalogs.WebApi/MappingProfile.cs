﻿using AutoMapper;
using Catalogs.Core.Dtos;
using Catalogs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogs.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CatalogItem, CatalogItemDto>().ForSourceMember(dest => dest.Catalog, opt => opt.Ignore());
            CreateMap<CatalogItemDto, CatalogItem>();

            CreateMap<Catalog, CatalogDto>();
            CreateMap<CatalogDto, Catalog>();
        }
    }
}
