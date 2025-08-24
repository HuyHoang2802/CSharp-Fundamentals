using Buoi2_DataAccess.Models;
using Buoi2_Repositories;

namespace PRN212_Buoi2_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepo repo = new ProductRepo();
            var list = repo.ReadData();
            Product pCreate = new Product();
            pCreate.ProductId = 3;
            pCreate.Name = "laptop galaxy";
            pCreate.Price = 100;
            pCreate.Quantity = 500;
             repo.UpdateData(pCreate);
           var li = repo.ReadData();
            foreach (var item in li)
            { 
                Console.WriteLine(item);
            }

            

        }
    }
}
