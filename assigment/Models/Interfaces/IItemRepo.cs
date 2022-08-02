using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface IItemRepo
    {
        List<Item> GetItems();

        Item FindItem(int id);
        Item SearchItem(string search);

        Item CreateItem(CreateItemViewModel model);
        bool DeleteItem(Item model);

        void UpdateItem(Item model);

    }
}
