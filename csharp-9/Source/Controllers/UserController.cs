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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            var bothHaveValues = (!string.IsNullOrEmpty(accelerationName) && companyId.HasValue);
            var nobodyHasValues = (string.IsNullOrEmpty(accelerationName) && companyId is null);

            if (bothHaveValues || nobodyHasValues) return NoContent();

            var users = new List<UserDTO>();
            if (companyId.HasValue)
            {
                users = _service.FindByCompanyId(companyId.Value)
                                    .Select(user => _mapper.Map<UserDTO>(user))
                                    .ToList();
            }
            else
            {
                users = _service.FindByAccelerationName(accelerationName)
                                    .Select(user => _mapper.Map<UserDTO>(user))
                                    .ToList();
            }
            return Ok(users);
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _mapper.Map<UserDTO>(_service.FindById(id));
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            User user = _mapper.Map<User>(value);
            var saved = _mapper.Map<UserDTO>(_service.Save(user));
            return Ok(saved);
        }

    }
}
