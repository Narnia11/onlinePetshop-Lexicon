using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category FindCategory(int id);
        Category SearchCategory(string search);

        void CreateCategory(CreateCategoryViewModel person);
        void DeleteCategory(Category person);
        void UpdateCategory(Category person);

        string ConvertToBase64(string path);
    }
}
