using BolaoShow.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BolaoShow.Data.Mappings
{
    public class SorteioMapping : IEntityTypeConfiguration<Sorteio>
    {
        public void Configure(EntityTypeBuilder<Sorteio> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Dezena_01)
                .IsRequired();

            builder.Property(s => s.Dezena_02)
                .IsRequired();

            builder.Property(s => s.Dezena_03)
                .IsRequired();

            builder.Property(s => s.Dezena_04)
                .IsRequired();

            builder.Property(s => s.Dezena_05)
                .IsRequired();

            builder.ToTable("Sorteios");
        }
    }
}
