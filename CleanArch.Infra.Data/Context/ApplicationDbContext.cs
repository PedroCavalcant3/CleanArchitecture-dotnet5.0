using CleanArch.Domain.Entities;
using CleanArch.Infra.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Context {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        
        //Mapeando a entidade criada no arquivo de contexto
        public DbSet<Product> Products { get; set; }

        //Utilizar 'FLUENT API' para fazer a configuracao da entidade "a parte" (sem utilizar 'object notation', sendo utilizada uma lógica igual).
        //A 'FLUENT API' é definida no arquivo de contexto, utilizando o modelo OnModelCreating pode-se criar uma mesma lógica de Object's Notation.
        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
