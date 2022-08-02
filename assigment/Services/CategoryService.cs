using Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepo _CategoryRepo;
        public CategoryService(ICategoryRepo CategoryRepo)
        {
            this._CategoryRepo = CategoryRepo;
        }

        public string ConvertToBase64( string path)
        {
            using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

        public void CreateCategory(CreateCategoryViewModel category)
        {
            _CategoryRepo.CreateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _CategoryRepo.DeleteCategory(category);

        }

        public Category FindCategory(int id)
        {
            return _CategoryRepo.FindCategory(id);
        }

        public List<Category> GetCategories()
        {
           return _CategoryRepo.GetCategorys();
        }

        public List<Category> GetCategorys()
        {
            return _CategoryRepo.GetCategorys();
        }

        public Category SearchCategory(string search)
        {
            return _CategoryRepo.SearchCategory(search);
        }

        public void UpdateCategory(Category category)
        {
            _CategoryRepo.UpdateCategory(category);
        }
    }
}
