using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = _mapper.Map<CompanyDTO>(_service.FindById(id));
            return Ok(company);
        }


        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            var bothHaveValues = (accelerationId.HasValue && userId.HasValue);
            var nobodyHasValues = (accelerationId is null && userId is null);

            if (bothHaveValues || nobodyHasValues) return NoContent();

            var companies = new List<CompanyDTO>();
            if (userId.HasValue)
            {
                companies = _service.FindByUserId(userId.Value)
                                .Select(company => _mapper.Map<CompanyDTO>(company))
                                .ToList();
            }
            else
            {
                companies = _service.FindByAccelerationId(accelerationId.Value)
                                .Select(company => _mapper.Map<CompanyDTO>(company))
                                .ToList();
            }
            return Ok(companies);
        }




        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            Company company = _mapper.Map<Company>(value);
            var saved = _mapper.Map<CompanyDTO>(_service.Save(company));
            return Ok(saved);
        }
    }
}
