using Microsoft.AspNetCore.Identity;
using Register_A_Person_In_A_Database_Backend_.Dto;
using Register_A_Person_In_A_Database_Backend_.Models;

namespace Register_A_Person_In_A_Database_Backend_.Data.Interfaces
{
    public interface IPeopleRepository
    {
        Task<People> CreatePersonAsync(People person);
        Task<People> GetPersonByIdAsync(int id);
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task UpdatePersonAsync(int id, People updatedPerson);
        Task DeletePersonAsync(int id);
        Task<IEnumerable<People>> SearchPeopleAsync(string name);

    }

}
