﻿using Back_End_Persona.Core.Entities;
using Back_End_Persona.Core.ViewModel;
using Back_End_Persona.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly PersonaContext _context;


        public PersonaController(IPersonaRepository personaRepository, PersonaContext context)
        {
            _personaRepository = personaRepository;
            _context = context;

        }

        [HttpGet("[action]")]
        public IActionResult GetPersonas()
        {
            var personasList = _personaRepository.GetAllPersonas();
            return Ok(personasList);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPersonasById(int id)
        {
            var persona = _personaRepository.GetPersonasById(id);
            return Ok(persona);
        }


        [HttpPut("[action]/{id}")]
        public IActionResult UpdatePersona(string id, PersonaViewModel persona)
        {
            //Validar que exista usuario en la base de datos, posterior a eso actulizar el registro.
            var currentEntity = _context.Persona.Where(x => x.IdPersona == int.Parse(id)).FirstOrDefault();

            if (currentEntity != null)
            {
                _personaRepository.AddOrUpdatePersona(persona, id);
                return Ok("Persona actualizada Correctamente");
            }
            else
            {
                return BadRequest("Debe sumistrar al sistema un Id Existente");
            }
        }


        [HttpPost(nameof(InsertPersonas))]
        public IActionResult InsertPersonas(PersonaViewModel viewModel)
        {
            _personaRepository.AddOrUpdatePersona(viewModel, "");
            return Ok("Persona Insertado Correctamente");
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeletePersonas(int id)
        {
            var currentEntity = _context.Persona.Where(x => x.IdPersona == id).FirstOrDefault();

            if (currentEntity != null)
            {
                _personaRepository.DeletePersona(id);
                return Ok("Persona Eliminado Correctamente");
            }
            else
            {
                return BadRequest("Debe sumistrar al sistema un Id Existente");
            }

        }


    }

}