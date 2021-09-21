using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoTech.VideoApplication2021.WebApi.Dtos.Insurance;
using InnotTech.VideoApplication2021.Core.IServices;
using InnotTech.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.VideoApplication2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAll()
        {
            try
            {
                return Ok(_insuranceService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> ReadById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

        [HttpPost]
        public ActionResult<GetIdInsuranceDto> Create([FromBody] PostInsuranceDto dto)
        {
            try
            {
                var insuranceSaved = _insuranceService.Create(new Insurance
                {
                    Name = dto.Name,
                    Price = dto.Price
                });
                return Ok(new GetIdInsuranceDto
                {
                    Id = insuranceSaved.Id,
                    Name = insuranceSaved.Name
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<Insurance> Delete(int id)
        {
            try
            {
                return Ok(_insuranceService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> Update(int id, [FromBody] Insurance insurance)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("ID in insurance must match param id");
                }
                return Ok(_insuranceService.Update(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
        }

    }
}