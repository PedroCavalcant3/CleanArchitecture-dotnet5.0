using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfigurations {
    
    //Configuracao de Entidade (Aqui posso codar como a entidade vai se comportar em relação a sua construção utilizando 'Fluent API')
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);

            //Elemento 'HasData' verifica se dados está na tabela em DB, caso não negativo, é feita a inclusão de uma tabela.
            builder.HasData(
                new Product {
                    Id = 1,
                    Name = "Caderno",
                    Description = "Caderno espiral 100 folhas",
                    Price = 9.45m
                },
                new Product {
                    Id = 2,
                    Name = "Borracha",
                    Description = "Borracha de Latex",
                    Price = 9.45m
                },
                new Product {
                    Id = 3,
                    Name = "Lapis",
                    Description = "Lapis Nº 2.0",
                    Price = 9.45m
                }
                );

        }
    }
}
