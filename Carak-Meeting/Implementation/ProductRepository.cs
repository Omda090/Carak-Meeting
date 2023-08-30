using Carak_Meeting.Data;
using Carak_Meeting.Interfaces;
using Carak_Meeting.Models;
using Microsoft.EntityFrameworkCore;

namespace Carak_Meeting.Implementation
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void Add(Product product)
        {
            _context.Set<Product>().Add(product);
        }

        public async Task<Product> DeleteProductById(int productid)
        {
            return await _context.products.FirstOrDefaultAsync(product => product.id == productid);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product> GetProductById(int productid)
        {
            return await _context.products.FirstOrDefaultAsync(carak => carak.id == productid);
        }

        public  void Remove(Product product)
        {
              _context.Remove(product);
        }

        public async Task<bool> SaveAll()
        {
         return  await _context.SaveChangesAsync() > 0 ;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

      
    }
}
