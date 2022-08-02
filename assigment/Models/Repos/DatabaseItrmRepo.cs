using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Repository.Interfaces;
using Model.Enums;
using Model;

namespace assignment.Models
{
    public class DatabaseItemRepo: IItemRepo
    {
        private ExDBContext _DBContext;
        private IHostingEnvironment _HostingEnviroment;
        private IMediaRepositoryInterface _MediaRepository;


        public DatabaseItemRepo(ExDBContext myDBContext, IHostingEnvironment hostingEnviroment, IMediaRepositoryInterface mediaRepository)
        {
            _DBContext = myDBContext;
            _HostingEnviroment = hostingEnviroment;
            _MediaRepository = mediaRepository;

        }

        public Item CreateItem(CreateItemViewModel model)
        {
            string uniqeFileNamePrimaryPhoto = null;
            String filePathPrimaryPhoto = null;
            if (model.Item_PrimaryPhoto != null)
            {
                String uploadsFolder = Path.Combine(_HostingEnviroment.WebRootPath, "media\\images");
                uniqeFileNamePrimaryPhoto = Guid.NewGuid().ToString() + "_" + model.Item_PrimaryPhoto.FileName;
                filePathPrimaryPhoto = Path.Combine(uploadsFolder, uniqeFileNamePrimaryPhoto);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                model.Item_PrimaryPhoto.CopyTo(new FileStream(filePathPrimaryPhoto, FileMode.Create));
            }

            Item item = new Item
            {
                Item_Name = model.Item_Name,
                Item_price=model.Item_price,
                Item_Category_id=model.Item_Category_id,
                Item_description = model.Item_description,
                CreationDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,

            };

        _DBContext.Items.Add(item);
            _DBContext.SaveChanges();

            Media media = new Media
            {
                Media_Name = model.Item_PrimaryPhoto.FileName,
                Media_path = filePathPrimaryPhoto,
                Media_Type = (byte)MediaTypeEnum.IntroImage,
                Media_Item_id = item.Item_id,
                LastUpdateDateTime = DateTime.Now,
                CreationDateTime = DateTime.Now

            };
            _MediaRepository.Add(media);
         

            return item;
 
        }


        public bool DeleteItem(Item model)
        {
            if (model.Medias.Count > 0)
            {
                foreach (var media in model.Medias)
                {

                    string file_Path = media.Media_path;
                    string path = file_Path;
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        file.Delete();

                    }

                }
                var medias = _MediaRepository.GetMedias().Where(x => x.Media_Item_id == model.Item_id);
                _MediaRepository.RemoveRange(medias);

            }
            if (model != null)
                _DBContext.Items.Remove(model);
            _DBContext.SaveChanges();

            var result = _DBContext.Items.Find(model.Item_id);
            if (result != null)
                return true;
            else
               return false;


        }



        public Item FindItem(int id)
        {
            return _DBContext.Items.Include(n => n.Medias).FirstOrDefault(x => x.Item_id == id);

        }

        public List<Item> GetItems()
        {
            return _DBContext.Items.Include(x=>x.Medias).ToList();
        }



        public Item SearchItem(string search)
        {
            return _DBContext.Items.FirstOrDefault(x => x.Item_Name.ToLower().Contains(search.ToLower()) ||x.Item_Name.Contains(search.ToLower()));

        }

        public void UpdateItem(Item model)
        {
            _DBContext.Items.Update(model);
            _DBContext.SaveChanges();


        }


 
    }
}
