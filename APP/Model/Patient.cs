using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP.Model
{
    public class Patient
    {
        [JsonPropertyName("id")]
        public int PatientId { get; set; }

        [JsonPropertyName("full_name")]
        public string? PatientName { get; set; }

        [JsonPropertyName("phone")]
        public string? MobileNo { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        [JsonPropertyName("date_of_birth")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? CreatedDate { get; set; }
    }

    // Wrapper matching the { "status": ..., "data": ... } envelope
    // returned by get_patients.php / get_patient.php
    public class ApiListResponse<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }


}
