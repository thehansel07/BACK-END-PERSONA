using Back_End_Persona.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End_Persona.Infrastructure.Data.ModelCreatingConfigurations
{
    public class PersonasConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.IdPersona);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.FechaDeNacimiento)
                .IsRequired()
                .IsUnicode(false);
        }

    }
}
