using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Register_A_Person_In_A_Database_Backend_.Data.Interfaces;
using Register_A_Person_In_A_Database_Backend_.Models;

namespace Register_A_Person_In_A_Database_Backend_.Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ApplicationDbContext _context;

        public PeopleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve a person by ID
        public async Task<People> GetPersonByIdAsync(int id)
        {
            return await _context.Peoples.FindAsync(id);
        }

        // Search for people by name
        public async Task<IEnumerable<People>> SearchPeopleAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                // If the name is empty or contains only whitespace, return all items
                return await _context.Peoples.ToListAsync();
            }
            else
            {
                // Split the input name into separate parts for first name and last name
                string[] nameParts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string firstName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
                string lastName = nameParts.Length > 1 ? nameParts[1] : string.Empty;

                return await _context.Peoples
                    .Where(p => p.FirstName.Contains(firstName) || p.LastName.Contains(lastName))
                    .ToListAsync();
            }
        }

        // Retrieve all people
        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.Peoples.ToListAsync();
        }

        // Create a new person
        public async Task<People> CreatePersonAsync(People person)
        {
            _context.Peoples.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        // Update an existing person
        public async Task UpdatePersonAsync(int id, People updatedPerson)
        {
            var existingPerson = await _context.Peoples.FindAsync(id);
            if (existingPerson != null)
            {
                // Update properties
                existingPerson.FirstName = updatedPerson.FirstName;
                existingPerson.LastName = updatedPerson.LastName;
                existingPerson.PhoneNumber = updatedPerson.PhoneNumber;
                existingPerson.Birthplace = updatedPerson.Birthplace;
                existingPerson.Birthday = updatedPerson.Birthday;
                existingPerson.JobStatus = updatedPerson.JobStatus;
                existingPerson.MarriageStatus = updatedPerson.MarriageStatus;
                existingPerson.Gender = updatedPerson.Gender;

                await _context.SaveChangesAsync();
            }
        }

        // Delete a person
        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.Peoples.FindAsync(id);
            if (person != null)
            {
                _context.Peoples.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
