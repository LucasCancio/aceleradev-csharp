using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _service;
        private readonly IMapper _mapper;
        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            var bothHaveValues = (accelerationId.HasValue && userId.HasValue);
            if (!bothHaveValues) return NoContent();

            IEnumerable<ChallengeDTO> challenges = _service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value)
                     .Select(challenge => _mapper.Map<ChallengeDTO>(challenge))
                     .ToList();

            return Ok(challenges);

        }




        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            Models.Challenge challenge = _mapper.Map<Models.Challenge>(value);
            var saved = _mapper.Map<ChallengeDTO>(_service.Save(challenge));
            return Ok(saved);
        }
    }
}
