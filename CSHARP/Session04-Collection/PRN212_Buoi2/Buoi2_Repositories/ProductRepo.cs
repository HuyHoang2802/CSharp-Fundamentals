using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buoi2_DataAccess.Models;

namespace Buoi2_Repositories
{
    public class ProductRepo
    {
        //CRUD
        Prn212DatabaseFirstContext context;
        public ProductRepo() 
        {
        context = new Prn212DatabaseFirstContext();
        
        }
        public List<Product> ReadData()//trả về dữ liệu có trong bảng product 

        {
            return context.Products.ToList();
        }

        public void CreateData(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }



        public Product GetProductById(int id) 
        {
                
            return context.Products.FirstOrDefault(x => x.ProductId == id);
        }
        public void DeleteItem(int id)
        {
            var p = GetProductById(id);
            if (p != null)
            {
                context.Products.Remove(p);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
        public void UpdateData(Product product)
        {
            var p = GetProductById(product.ProductId);
            if ( p != null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                p.Quantity = product.Quantity;
                context.Products.Update(p);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not found!!!!");
            }

                
        }
    }
}
//Tạo bảng : Student: ID, name. class, major 
//           LecturerL ID, name, Major, DoB 

//Tạo 2 class RepoL lecturer và student
//Tạo các method CRUD + FindById(id)
//Test trong hàm main