using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using Register_A_Person_In_A_Database_Backend_.Data.Interfaces;
using Register_A_Person_In_A_Database_Backend_.Models;

namespace Register_A_Person_In_A_Database_Backend_.Controllers
{
    [ApiController]
    [Authorize] // Require authorized access for all controller actions
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            // Retrieve a person by their unique ID

            var person = await _peopleRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            // Retrieve all people in the database

            var people = await _peopleRepository.GetAllPeopleAsync();
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] People person)
        {
            // Create a new person record

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPerson = await _peopleRepository.CreatePersonAsync(person);
            return Ok(createdPerson);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")] // Require "Admin" role for update action
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] People updatedPerson)
        {
            // Update an existing person's information

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _peopleRepository.UpdatePersonAsync(id, updatedPerson);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")] // Require "Admin" role for delete action
        public async Task<IActionResult> DeletePerson(int id)
        {
            // Delete a person by their ID

            var person = await _peopleRepository.GetPersonByIdAsync(id);

            if (person != null)
            {
                await _peopleRepository.DeletePersonAsync(id);
                return Ok(person);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchPeopleByName([FromQuery] string name)
        {
            // Search for people by name (first name or last name)

            var people = await _peopleRepository.SearchPeopleAsync(name);
            return Ok(people);
        }
    }
}
