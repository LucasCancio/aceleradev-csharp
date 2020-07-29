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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _service;
        private readonly IMapper _mapper;
        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            var acceleration = _mapper.Map<AccelerationDTO>(_service.FindById(id));
            return Ok(acceleration);
        }


        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (!companyId.HasValue) return NoContent();

            IEnumerable<AccelerationDTO> accelerations = _service.FindByCompanyId(companyId.Value)
                     .Select(acceleration => _mapper.Map<AccelerationDTO>(acceleration))
                     .ToList();

            return Ok(accelerations);
        }




        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            Acceleration acceleration = _mapper.Map<Acceleration>(value);
            var saved = _mapper.Map<AccelerationDTO>(_service.Save(acceleration));
            return Ok(saved);
        }
    }
}
