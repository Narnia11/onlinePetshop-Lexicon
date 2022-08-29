using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Model;
using Repository.Interfaces;

namespace teachwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController: ControllerBase
    {

        private readonly IItemRepo _Itemcontext;
        private IMediaRepositoryInterface _MediaRepository;
        private IHostingEnvironment _HostingEnviroment;
        private IItemService _ItemService;
        public ItemController(IItemRepo itemcontext, IHostingEnvironment hostingEnviroment,IItemService itemService, IMediaRepositoryInterface mediaRepository)
        {
            _Itemcontext = itemcontext;
            _HostingEnviroment = hostingEnviroment;
            _MediaRepository = mediaRepository;
            _ItemService = itemService;

        }



        [HttpGet]

        [Route("GetItems")]
        public IActionResult GetItems()
        {
            return Ok(_ItemService.GetItems());
        
        }
        [HttpGet]

        [Route("GetRecentItems")]
        public IActionResult RecentItems()
        {
          var result=  _ItemService.GetItems().ToList().Take(5);
            return Ok(result);

        }
        [HttpGet]
        [Route("GetItem/{id}")]

        public IActionResult GetItem(int id)
        {
            return Ok(_ItemService.GetItems().Where(x=>x.Item_id==id).FirstOrDefault());
        }
        [HttpDelete]
        [Route("DeleteItem/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _ItemService.DeleteItem(_ItemService.FindItem(id));
                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
        [HttpPost]
        [Route("AddItem")]
        public IActionResult Post([FromForm] CreateItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _ItemService.CreateItem(model);
                return Ok();


            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPost]
        [Route("UpdateItem")]
        public IActionResult UpdateItem([FromForm]  Item model)
        {
            _ItemService.UpdateItem(model);
            return Ok();
        }





    }

}
