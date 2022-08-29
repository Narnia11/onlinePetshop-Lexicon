using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class ItemService : IItemService
    {
        private IItemRepo _ItemRepo;
        public ItemService(IItemRepo ItemRepo)
        {
            this._ItemRepo = ItemRepo;
        }

        public void CreateItem(CreateItemViewModel category)
        {
            _ItemRepo.CreateItem(category);
        }

        public void DeleteItem(Item item)
        {
            _ItemRepo.DeleteItem(item);

        }

        public string ConvertToBase64(string path)
        {
            using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
            fileStream.Dispose();


        }


        public Item FindItem(int id)
        {
            return _ItemRepo.FindItem(id);
        }


        public List<Item> GetItems()
        {
            return _ItemRepo.GetItems();
        }

        public Item SearchItem(string search)
        {
            return _ItemRepo.SearchItem(search);
        }

        public void UpdateItem(Item category)
        {
            _ItemRepo.UpdateItem(category);
        }



        Item IItemService.FindItem(int id)
        {
            return _ItemRepo.FindItem(id);
        }


        Item IItemService.SearchItem(string search)
        {
            throw new NotImplementedException();
        }
    }
}
