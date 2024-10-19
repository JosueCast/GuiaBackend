using Backend.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private IPersonaServices _personaServices;

        public PersonaController([FromKeyedServices("personaservices")]IPersonaServices personaServices)
        {
            //instancia de clase
            _personaServices = new PersonaServices();


        }


        [HttpGet("all")]
        public List<PersonaDatos> GetPersonaDatos() => Repository.persona;

        [HttpGet("{id}")]

        //public PersonaDatos getPersonaDatos(int id) => Repository.persona.FirstOrDefault(p => p.id == id);

        //[HttpGet("{id}")]

        public ActionResult<PersonaDatos> Get(int id)
        {
            var persona = Repository.persona.FirstOrDefault(p =>p.id == id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }


        [HttpGet("search/{search}")]
        public List<PersonaDatos> Get(string search) => Repository.persona.Where(p => p.name.Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult add(PersonaDatos persona)
        {
            if (!_personaServices.validate(persona)){
                return BadRequest();
            }
            Repository.persona.Add(persona);
            return NoContent();
        }


    }
}
