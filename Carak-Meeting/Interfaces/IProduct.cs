using Carak_Meeting.Models;

namespace Carak_Meeting.Interfaces
{
    public interface IProduct
    {

        Task<IEnumerable<Product>> GetAllProduct();

        Task<Product> GetProductById(int productid);

        Task<Product> DeleteProductById(int productid);

        void Add(Product product);

        void Remove(Product product);

        Task<bool> SaveChanges();
        Task<bool> SaveAll();
    }
}
