using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP.Model
{
    public class Dentist
    {
        public int DentistId { get; set; }
        public int? UserId { get; set; }
        public string DentistCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Specialization { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePhoto { get; set; }
       
        [JsonPropertyName("CreatedAt")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("UpdatedAt")]
        [JsonConverter(typeof(MyNullableDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }
}
