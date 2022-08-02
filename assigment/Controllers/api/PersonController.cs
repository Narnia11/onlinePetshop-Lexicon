using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace teachwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController: ControllerBase
    {

        private IPeopleService _personService;

        public PersonController(IPeopleService peopleService )
        {
            _personService = peopleService;
     
        }


        [HttpGet]

        [Route("GetPersons")]
        public IActionResult GetPersons()
        {
            return Ok(_personService.GetPeoples());
        
        }
        [HttpGet]
        [Route("GetPerson/{id}")]

        public IActionResult GetPerson(int id)
        {
            return Ok(_personService.GetPeoples().Where(x=>x.Id==id).FirstOrDefault());
        }
        [HttpGet]
        [Route("DeletePerson/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _personService.DeletePerson(_personService.FindPerson(id));
                return Ok();
            }
            catch
            {
                return Ok();
            }
        }
        [HttpPost]
        [Route("AddPerson")]
        public IActionResult Post(Person person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _personService.CreatePerson(person);
                return Ok();


            }
            catch
            {
                return BadRequest();
            }
        }





    }
}
