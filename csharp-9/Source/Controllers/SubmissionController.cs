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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;
        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore(int? challengeId)
        {
            if (!challengeId.HasValue) return NoContent();

            var score = _service.FindHigherScoreByChallengeId(challengeId.Value);
            return Ok(score);
        }


        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? accelerationId = null, int? challengeId = null)
        {
            var bothHaveValues = (accelerationId.HasValue && challengeId.HasValue);
            if (!bothHaveValues) return NoContent();

            IEnumerable<SubmissionDTO> submissions = _service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value)
                     .Select(submission => _mapper.Map<SubmissionDTO>(submission))
                     .ToList();

            return Ok(submissions);

        }




        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            Submission submission = _mapper.Map<Submission>(value);
            var saved = _mapper.Map<SubmissionDTO>(_service.Save(submission));
            return Ok(saved);
        }
    }
}
