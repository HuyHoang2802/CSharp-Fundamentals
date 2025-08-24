using BusinessObjects;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo iCategoryRepo;
        public CategoryService()
        {
            iCategoryRepo = new CategoryRepo();
        }
        public List<Category> GetCategories()
        {
            return iCategoryRepo.GetCategories();
        }
    }
}
