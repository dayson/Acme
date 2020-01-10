using Acme.Data;
using Acme.Data.Entities;
using Acme.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Acme.Controllers
{
    [Route("api/[Controller]")]
    public class PersonsController : Controller
    {
        private readonly IAcmeRepository _repository;
        private readonly ILogger<PersonsController> _logger;
        private readonly IMapper _mapper;

        public PersonsController(IAcmeRepository repository, ILogger<PersonsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(_repository.GetAllPersons()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetAllPersons() : {ex}");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var person = _repository.GetPersonById(id);

                if (person != null)
                {
                    return Ok(_mapper.Map<Person, PersonViewModel>(person));
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetPersonById() : {ex}");
                return BadRequest($"Failed to get person");
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm]PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPerson = _mapper.Map<PersonViewModel, Person>(model);

                    _repository.AddEntity(newPerson);
                    if (_repository.SaveAll())
                    {
                        return Redirect("/listing");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save person : {ex}");
            }

            return BadRequest("Failed to save person");
        }
    }
}
