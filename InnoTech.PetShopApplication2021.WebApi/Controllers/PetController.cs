using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.PetShopApplication2021.WebApi.Dtos;
using InnotTech.PetShopApplication2021.Core.Filtering;
using InnotTech.PetShopApplication2021.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.PetShopApplication2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<GetAllPetDto> GetAll([FromQuery] Filter filter)
        {
            try
            {
                var totalCount = _petService.GetTotalPetCount();
                var list = _petService.GetAllPets(filter);
                return Ok(new GetAllPetDto
                {
                    List = list.Select(p => new GetPetDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList(),
                    TotalCount = totalCount
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Oh Oh");
            }
            
        }
    }
}