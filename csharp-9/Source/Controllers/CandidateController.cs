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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            var candidate = _mapper.Map<CandidateDTO>(_service.FindById(userId, accelerationId, companyId));
            return Ok(candidate);
        }


        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? accelerationId = null, int? companyId = null)
        {
            var bothHaveValues = (accelerationId.HasValue && companyId.HasValue);
            var nobodyHasValues = (accelerationId is null && companyId is null);

            if (bothHaveValues || nobodyHasValues) return NoContent();

            var candidates = new List<CandidateDTO>();
            if (companyId.HasValue)
            {
                candidates = _service.FindByCompanyId(companyId.Value)
                                .Select(candidate => _mapper.Map<CandidateDTO>(candidate))
                                .ToList();
            }
            else
            {
                candidates = _service.FindByAccelerationId(accelerationId.Value)
                                .Select(candidate => _mapper.Map<CandidateDTO>(candidate))
                                .ToList();
            }

            return Ok(candidates);

        }




        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            Candidate candidate = _mapper.Map<Candidate>(value);
            var saved = _mapper.Map<CandidateDTO>(_service.Save(candidate));
            return Ok(saved);
        }
    }
}
