using BolaoShow.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoShow.Data.Mappings
{
    public class ConcursoMapping : IEntityTypeConfiguration<Concurso>
    {
        public void Configure(EntityTypeBuilder<Concurso> builder)
        {
            builder.ToTable("Concursos", schema: "bolao");
        }
    }
}
