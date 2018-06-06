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
    [Route("api/Catalogs")]
    public class CatalogsController : Controller
    {
        private readonly ICatalogUnit _catalogUnit;
        private readonly IMapper _mapper;
        public CatalogsController(ICatalogUnit catalogUnit, IMapper mapper)
        {
            _catalogUnit = catalogUnit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            Guid _id = new Guid();
            if (!Guid.TryParse(id, out _id))
            {
                return Ok();
            }
            try
            {
                Catalog d = await _catalogUnit.CatalogRepository.GetByID(_id);
                if (d == null)
                {
                    return Ok();
                }

                CatalogDto catalogs = _mapper.Map<CatalogDto>(d);
                return Ok(catalogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CatalogDto catalog)
        {
            if (catalog == null)
            {
                return Ok();
            }

            Catalog _catalog = _mapper.Map<Catalog>(catalog);
            if(_catalog == null)
            {
                return BadRequest();
            }
            await _catalogUnit.CatalogABCRepository.Insert(_catalog);
            await _catalogUnit.SaveChangesAsync();
            catalog = _mapper.Map<CatalogDto>(_catalog);
            return Ok(catalog);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CatalogDto catalog)
        {
            if (catalog == null)
            {
                return Ok();
            }
            try
            {
                Catalog _catalog = _mapper.Map<Catalog>(catalog);
                if(_catalog == null)
                {
                    return BadRequest();
                }

                _catalogUnit.CatalogABCRepository.Update(_catalog);
                await _catalogUnit.SaveChangesAsync();
                catalog = _mapper.Map<CatalogDto>(_catalog);
                return Ok(catalog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] CatalogDto catalog)
        {
            if (catalog == null)
            {
                return Ok();
            }
            try
            {
                Catalog _catalog = _mapper.Map<Catalog>(catalog);
                if(_catalog == null)
                {
                    return BadRequest();
                }
                _catalogUnit.CatalogRepository.Delete(_catalog.CatalogId);
                await _catalogUnit.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                 
            }

        }

    }
}