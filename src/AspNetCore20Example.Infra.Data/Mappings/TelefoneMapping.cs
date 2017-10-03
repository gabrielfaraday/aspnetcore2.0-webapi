using AspNetCore20Example.Domain.Contatos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore20Example.Infra.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DDD)
               .IsRequired();

            builder.Property(t => t.Numero)
               .HasColumnType("varchar(10)")
               .IsRequired();

            builder.Ignore(t => t.ValidationResult);
            builder.Ignore(t => t.CascadeMode);

            builder.HasOne(t => t.Contato)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ContatoId);

            builder.ToTable("Telefones");
        }
    }
}