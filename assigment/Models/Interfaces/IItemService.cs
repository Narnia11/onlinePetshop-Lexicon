using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface IItemService
    {
        List<Item> GetItems();

        Item FindItem(int id);
        Item SearchItem(string search);

        void CreateItem(CreateItemViewModel person);
        void DeleteItem(Item person);
        void UpdateItem(Item person);
        string ConvertToBase64(string path);

    }
}
