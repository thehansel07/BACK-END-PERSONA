using Back_End_Persona.Core.Entities;
using Back_End_Persona.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonaContext _context;
        private readonly IPersonaRepository _personaRepository;
        IConfiguration _configuration;


        public IPersonaRepository PersonaRepository => _personaRepository?? new PersonaRepository(_context, _configuration);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
