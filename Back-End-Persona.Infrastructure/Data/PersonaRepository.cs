using Back_End_Persona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Infrastructure.Data
{
    public class PersonaRepository: BaseRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(PersonaContext context): base(context)
        {

        }
    }
}
