using Acme.Data;
using Acme.Data.Entities;
using Acme.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Controllers
{
    [Route("/api/persons/{id}/activity")]
    public class ActivityController : Controller
    {
        private readonly IAcmeRepository _repository;
        private readonly ILogger<ActivityController> _logger;
        private readonly IMapper _mapper;

        public ActivityController(IAcmeRepository repository, ILogger<ActivityController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(string activity)
        {
            try
            {
                var persons = _repository.GetAllPersons().Where(x => x.Activity == activity).ToList();

                if (persons.Count > 0)
                {
                    return Ok(_mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(persons));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get activity: {ex}");
                return BadRequest("Failed to get activity");
            }
        }
    }
}
