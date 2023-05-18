using Back_End_Persona.Core.ViewModel;
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
        void AddOrUpdatePersona(PersonaViewModel persona,string id);
        void DeletePersona(int IdPersona);
        Persona GetPersonasById(int IdPersona);
    }
}
