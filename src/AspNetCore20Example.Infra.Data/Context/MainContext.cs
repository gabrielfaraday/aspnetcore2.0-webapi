using AspNetCore20Example.Domain.Contatos.Entities;
using Microsoft.EntityFrameworkCore;
using AspNetCore20Example.Infra.Data.Mappings;
using System.Linq;
using System;
using AspNetCore20Example.Domain.Usuarios.Entities;

namespace AspNetCore20Example.Infra.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<UsuarioDados> UsuarioDados { get; set; }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());

            modelBuilder.ApplyConfiguration(new UsuarioDadosMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property("DataCadastro").IsModified = false;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}
