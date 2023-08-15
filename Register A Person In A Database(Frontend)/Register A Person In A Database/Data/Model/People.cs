using Register_A_Person_In_A_Database.Data.Enums;
using Register_A_Person_In_A_Database_.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Register_A_Person_In_A_Database.Data.Model
{
    public class People
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Birthplace { get; set; }
        public JobStatus JobStatus { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
        public Gender Gender { get; set; }
    }
}
