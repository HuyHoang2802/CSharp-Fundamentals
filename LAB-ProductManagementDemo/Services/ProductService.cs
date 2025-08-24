using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo iProductRepo;
        public ProductService()
        {
            iProductRepo = new ProductRepo();
        }
        public void DeleteProduct(Product p)
        {
            iProductRepo.DeleteProduct(p);
        }

        public Product GetProductById(int id)
        {
            return iProductRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
           return iProductRepo.GetProducts();
        }

        public void SaveProduct(Product p)
        {
            iProductRepo.SaveProduct(p);
        }

        public void UpdateProduct(Product p)
        {
            iProductRepo.UpdateProduct(p);
        }
    }
}
