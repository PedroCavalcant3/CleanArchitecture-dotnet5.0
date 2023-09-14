using System;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Infra.Data.Context;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories {

    //Incluindo a referência, herdando a 'Interface' criada para 'Product'
    public class ProductRepository : IProductRepository {
        
        //Incluindo uma instância no arquivo de contexto;
        private ApplicationDbContext _context;

        //Injetando a instância no construtor;
        public ProductRepository(ApplicationDbContext context) {

            _context = context;

        }

        //Usando a instância do contexto para obter os dados do produto
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }
        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
        public void Remove(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

    }
}
