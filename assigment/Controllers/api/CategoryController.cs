using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Repository.Interfaces;

namespace teachwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {

        private readonly ICategoryRepo _Categorycontext;
        private IMediaRepositoryInterface _MediaRepository;
        private IHostingEnvironment _HostingEnviroment;
        private ICategoryService _CategoryService;
        public CategoryController(ICategoryRepo categorycontext, IHostingEnvironment hostingEnviroment,ICategoryService categoryService, IMediaRepositoryInterface mediaRepository)
        {
            _Categorycontext = categorycontext;
            _HostingEnviroment = hostingEnviroment;
            _MediaRepository = mediaRepository;
            _CategoryService = categoryService;

        }



        [HttpGet]

        [Route("GetCategorys")]
        public IActionResult GetCategorys()
        {
            return Ok(_CategoryService.GetCategories());
        
        }
        [HttpGet]
        [Route("GetCategory/{id}")]

        public IActionResult GetCategory(int id)
        {
            var result = _CategoryService.GetCategories().Where(x => x.Category_id == id).FirstOrDefault();
            //get image of this category and convert it to base 64
            string imgbase64=_CategoryService.ConvertToBase64(result.Medias.FirstOrDefault().Media_path);
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Category_id = result.Category_id,
                Category_description = result.Category_description,
                Category_name = result.Category_name,
                Category_Type = result.Category_Type,
                 Category_ImagePath = imgbase64

            };
            return Ok(categoryViewModel);
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _CategoryService.DeleteCategory(_CategoryService.FindCategory(id));
                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
        [HttpPost]
        [Route("AddCategory")]
        public IActionResult Post([FromForm] CreateCategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _CategoryService.CreateCategory(model);
                return Ok();


            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory([FromForm]  Category model)
        {
            _CategoryService.UpdateCategory(model);
            return Ok();
        }





    }

}
