using CrudWebApi.Data;
using CrudWebApi.Models;
using CrudWebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CrudWebApi.Controllers
{
    //localhost: xxxxx/api/person
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AplicationDBContext dbContext;

        public PersonController(AplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPerson()
        {
            return Ok(dbContext.Person.ToList());

        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPersonbyId(Guid id)
        {
            var person = dbContext.Person.Find(id);

            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }



        [HttpPost]
        public IActionResult AddPerson(AddPersonDto addPersonDto)
        {
            var personEntity = new Person()
            {
                Name = addPersonDto.Name,
                LastName = addPersonDto.LastName,
                Age = addPersonDto.Age,
                Sex = addPersonDto.Sex,
                SkinColor = addPersonDto.SkinColor,
                Nationality = addPersonDto.Nationality,
                PhoneNumber = addPersonDto.PhoneNumber

            };



            dbContext.Person.Add(personEntity);
            dbContext.SaveChanges();

            return Ok(personEntity);            
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePerson(Guid id, UpdatePersonDto updatePersonDto )
        {
            var person = dbContext.Person.Find(id);
            if (person is null){
                return NotFound(person);
            }
            person.Name = updatePersonDto.Name;
            person.LastName = updatePersonDto.LastName;
            person.Age = updatePersonDto.Age;

            return Ok(person);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeletePerson(Guid id)
        {
            var person = dbContext.Person.Find(id);

            if (person is null)
            {
                return NotFound();
            }
            dbContext.Person.Remove(person);
            dbContext.SaveChanges();


            return Ok();
        }


    }
}
