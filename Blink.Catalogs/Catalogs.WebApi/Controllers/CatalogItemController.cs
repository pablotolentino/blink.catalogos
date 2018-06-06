using System;
using System.Threading.Tasks;
using AutoMapper;
using Catalogs.Core.Dtos;
using Catalogs.Core.Entities;
using Catalogs.Core.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CatalogItem")]
    public class CatalogItemController : Controller
    {
        private readonly ICatalogItemUnit _catalogItemUnit;
        private readonly IMapper _mapper;
        public CatalogItemController(ICatalogItemUnit catalogItemUnit, IMapper mapper)
        {
            _catalogItemUnit = catalogItemUnit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                Guid _id = Guid.Empty;
                if (!Guid.TryParse(id, out _id))
                {
                    return BadRequest();
                }

                CatalogItem catalogItem = await _catalogItemUnit.CatalogItemABCRepository.GetByID(_id);
                if (catalogItem == null)
                {
                    return Ok();
                }
                CatalogItemDto catalogItemDto = _mapper.Map<CatalogItemDto>(catalogItem);
                return Ok(catalogItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CatalogItemDto catalogItemDto)
        {
            if (catalogItemDto == null)
            {
                return BadRequest();
            }
            try
            {

                CatalogItem catalogItem = _mapper.Map<CatalogItem>(catalogItemDto);              
                if(catalogItem == null)
                {
                    return BadRequest();
                }

                catalogItem.CatalogItemId = Guid.NewGuid();
                await _catalogItemUnit.CatalogItemABCRepository.Insert(catalogItem);
                await _catalogItemUnit.SaveChangesAsync();
                return Ok(catalogItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CatalogItemDto catalogItemDto)
        {
            if (catalogItemDto == null)
            {
                return BadRequest();
            }
            try
            {
                CatalogItem catalogItem = _mapper.Map<CatalogItem>(catalogItemDto);
                if(catalogItem == null)
                {
                    return BadRequest();
                }
                _catalogItemUnit.CatalogItemABCRepository.Update(catalogItem);
                await _catalogItemUnit.SaveChangesAsync();
                return Ok(catalogItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] CatalogItemDto catalogItemDto)
        {
            if (catalogItemDto == null)
            {
                return BadRequest();
            }
            try
            {
                CatalogItem catalogItem = _mapper.Map<CatalogItem>(catalogItemDto);
                if(catalogItem == null)
                {
                    return BadRequest();
                }
                _catalogItemUnit.CatalogItemRepository.Delete(catalogItem.CatalogItemId);
                await _catalogItemUnit.SaveChangesAsync();
                return Ok(catalogItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}