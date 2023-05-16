using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Core.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonaRepository PersonaRepository { get; }
        Task SaveChangesAsync();

    }
}
