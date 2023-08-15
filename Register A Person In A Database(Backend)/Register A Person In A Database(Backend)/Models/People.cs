using Microsoft.AspNetCore.Identity;
using Register_A_Person_In_A_Database_Backend_.Data.Enums;
using System.Text.Json.Serialization;

namespace Register_A_Person_In_A_Database_Backend_.Models
{
    public class People
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Birthplace { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JobStatus JobStatus { get; set; } = JobStatus.NotEmployed;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MarriageStatus MarriageStatus { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
    }
}
