using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface ICategoryRepo
    {
        List<Category> GetCategorys();

        Category FindCategory(int id);
        Category SearchCategory(string search);

        Category CreateCategory(CreateCategoryViewModel model);
        bool DeleteCategory(Category model);

        void UpdateCategory(Category model);

    }
}
