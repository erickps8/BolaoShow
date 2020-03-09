using BolaoShow.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoShow.Data.Mappings
{
    public class ApostaMapping : IEntityTypeConfiguration<Aposta>
    {
        public void Configure(EntityTypeBuilder<Aposta> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Dezena_01)
                .IsRequired();

            builder.Property(a => a.Dezena_02)
                .IsRequired();

            builder.Property(a => a.Dezena_03)
                .IsRequired();

            builder.Property(a => a.Dezena_04)
                .IsRequired();

            builder.Property(a => a.Dezena_05)
                .IsRequired();

            builder.Property(a => a.ValorAposta)
                .IsRequired();

            builder.ToTable("Apostas", schema:"bolao");
        }
    }
}
