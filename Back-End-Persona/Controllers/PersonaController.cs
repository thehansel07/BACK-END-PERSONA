using Back_End_Persona.Core.Entities;
using Back_End_Persona.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End_Persona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly PersonaContext _context;


        public PersonaController(IPersonaRepository personaRepository, PersonaContext context)
        {
            _personaRepository = personaRepository;
            _context = context;

        }

        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personasList = _personaRepository.GetAllPersonas();
            return Ok(personasList);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonasById(int id)
        {
            var persona = _personaRepository.GetPersonasById(id);
            return Ok(persona);
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePersona(int id, Persona persona)
        {
            //Validar que exista usuario en la base de datos, posterior a eso actulizar el registro.
            var obj = _context.Persona.Where(x => x.IdPersona == id).FirstOrDefault();

            if (obj != null)
            {
                _personaRepository.AddOrUpdatePersona(persona, id);
                return Ok("Persona actualizada Correctamente");
            }
            else
            {
                return BadRequest("Debe sumistrar al sistema un Id Existente");
            }
        }


        [HttpPost]
        public IActionResult InsertPersonas(Persona persona)
        {
            _personaRepository.AddOrUpdatePersona(persona, null);
            return Ok("Persona Insertado Correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePersonas(int id)
        {
            _personaRepository.DeletePersona(id);
            return Ok("Persona Eliminado Correctamente");
        }


    }

}