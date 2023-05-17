using Microsoft.EntityFrameworkCore;
using Back_End_Persona.Core.Entities;
using System.Reflection;


namespace Back_End_Persona.Infrastructure.Data
{
    public class PersonaContext : DbContext
    {
        public PersonaContext(DbContextOptions<PersonaContext> options) : base(options) { }

        public DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
