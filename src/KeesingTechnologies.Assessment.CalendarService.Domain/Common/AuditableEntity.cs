using System;
using System.Text.Json.Serialization;

namespace KeesingTechnologies.Assessment.CalendarService.Domain.Common
{
    public class AuditableEntity
    {
        [JsonIgnore]
        public string CreatedByIp { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public string LastModifiedByIp { get; set; }
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set; }
    }
}
