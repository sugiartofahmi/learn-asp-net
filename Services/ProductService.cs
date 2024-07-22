using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn_asp_net.Data;
using learn_asp_net.Models;
using Microsoft.EntityFrameworkCore;

namespace learn_asp_net.Services
{
    public class ProductService
    {
        private readonly ApplicationDBContext _context;
        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task Create(Product category)
        {
            _context.Products.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Product product, Product productRequest)
        {
            product.Name = productRequest.Name;
            product.Description = productRequest.Description;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await Get(id);
            if (product is null) return;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }



    }
}