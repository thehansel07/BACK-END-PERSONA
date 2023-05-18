using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Core.Entities
{
    public interface IPersonaRepository : IBaseRepository<Persona>
    {
        List<Persona> GetAllPersonas();
        void AddOrUpdatePersona(Persona persona, int? id);
        void DeletePersona(int IdPersona);
        Persona GetPersonasById(int IdPersona);
    }
}
