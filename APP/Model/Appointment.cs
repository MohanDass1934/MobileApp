using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DentistId { get; set; }
        [JsonConverter(typeof(MyDateTimeConverter))]
        public DateTime AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string Status { get; set; } = "pending";
        public string? Notes { get; set; }

        [JsonPropertyName("CreatedAt")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("UpdatedAt")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
        // Joined fields
        public string? PatientName { get; set; }
        public string? PatientPhone { get; set; }
        public string? DentistName { get; set; }
        public string? DentistSpecialization { get; set; }
    }
    public enum AppointmentStatus
    {
        pending,
        confirmed,
        completed,
        cancelled,
        rescheduled
    }
}
