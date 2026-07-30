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

        [JsonPropertyName("date_of_birth")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? CreatedDate { get; set; }

        [JsonPropertyName("patient_code")]
        public string? PatientCode { get; set; }

        [JsonPropertyName("allergies")]
        public string? Allergies { get; set; }

        [JsonPropertyName("medical_history")]
        public string? MedicalHistory { get; set; }

        [JsonPropertyName("emergency_contact_name")]
        public string? EmergencyContactName { get; set; }

        [JsonPropertyName("emergency_contact_phone")]
        public string? EmergencyContactPhone { get; set; }

        [JsonPropertyName("profile_photo")]
        public string? ProfilePhoto { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }

    // Detailed patient model for overview page
    public class PatientDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [JsonPropertyName("patient_code")]
        public string? PatientCode { get; set; }

        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("date_of_birth")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? DateOfBirth { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("allergies")]
        public string? Allergies { get; set; }

        [JsonPropertyName("medical_history")]
        public string? MedicalHistory { get; set; }

        [JsonPropertyName("emergency_contact_name")]
        public string? EmergencyContactName { get; set; }

        [JsonPropertyName("emergency_contact_phone")]
        public string? EmergencyContactPhone { get; set; }

        [JsonPropertyName("profile_photo")]
        public string? ProfilePhoto { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
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
