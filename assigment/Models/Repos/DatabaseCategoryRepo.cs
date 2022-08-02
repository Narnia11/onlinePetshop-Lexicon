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

namespace assignment.Models
{
    public class DatabaseCategoryRepo: ICategoryRepo
    {
        private ExDBContext _DBContext;
        private IHostingEnvironment _HostingEnviroment;
        private IMediaRepositoryInterface _MediaRepository;


        public DatabaseCategoryRepo(ExDBContext myDBContext, IHostingEnvironment hostingEnviroment, IMediaRepositoryInterface mediaRepository)
        {
            _DBContext = myDBContext;
            _HostingEnviroment = hostingEnviroment;
            _MediaRepository = mediaRepository;

        }

        public Category CreateCategory(CreateCategoryViewModel model)
        {
            string uniqeFileNamePrimaryPhoto = null;
            String filePathPrimaryPhoto = null;
            if (model.Category_PrimaryPhoto != null)
            {
                // String uploadsFolder = Path.Combine(_HostingEnviroment.WebRootPath, "..\\..\\React\\my-app\\public\\images\\");//for react
                String uploadsFolder = Path.Combine(_HostingEnviroment.WebRootPath, "media\\images");
                uniqeFileNamePrimaryPhoto = Guid.NewGuid().ToString() + "_" + model.Category_PrimaryPhoto.FileName;
                filePathPrimaryPhoto = Path.Combine(uploadsFolder, uniqeFileNamePrimaryPhoto);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                model.Category_PrimaryPhoto.CopyTo(new FileStream(filePathPrimaryPhoto, FileMode.Create));
            }

            Category category = new Category
            {
                Category_name = model.Category_name,
                Category_description = model.Category_description,
                CreationDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now,

            };
            _DBContext.Categories.Add(category);
            _DBContext.SaveChanges();

            Media media = new Media
            {
                Media_Name = model.Category_PrimaryPhoto.FileName,
                Media_path = filePathPrimaryPhoto,
                Media_Type = (byte)MediaTypeEnum.IntroImage,
                Media_Category_id = category.Category_id,
                LastUpdateDateTime = DateTime.Now,
                CreationDateTime = DateTime.Now

            };
            _MediaRepository.Add(media);
         

            return category;
 
        }


        public bool DeleteCategory(Category model)
        {
            var category = this.FindCategory(model.Category_id);
            if (category.Medias.Count > 0)
            {
                foreach (var media in category.Medias)
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
                var medias = _MediaRepository.GetMedias().Where(x => x.Media_Category_id == model.Category_id);
                _MediaRepository.RemoveRange(medias);

            }
            if (category != null)
                _DBContext.Categories.Remove(category);
            var result= _DBContext.Categories.Find(model.Category_id);
            if (result != null)
                return true;
            else
               return false;


        }



        public Category FindCategory(int id)
        {
            return _DBContext.Categories.Include(n => n.Medias).FirstOrDefault(x => x.Category_id == id);

        }

        public List<Category> GetCategorys()
        {
            return _DBContext.Categories.Include(x=>x.Medias).ToList();
        }



        public Category SearchCategory(string search)
        {
            return _DBContext.Categories.FirstOrDefault(x => x.Category_name.ToLower().Contains(search.ToLower()) ||x.Category_name.Contains(search.ToLower()));

        }

        public void UpdateCategory(Category model)
        {
            _DBContext.Categories.Update(model);
            _DBContext.SaveChanges();


        }


 
    }
}
