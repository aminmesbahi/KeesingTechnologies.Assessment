using KeesingTechnologies.Assessment.CalendarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeesingTechnologies.Assessment.CalendarService.Domain.Entities
{
    [Table("Events")]
    public class Event : AuditableEntity
    {       
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [MaxLength(60)]
        public string Location { get; set; }
        public ICollection<string> Members { get; set; }
        = new List<string>();

        [MaxLength(60)]
        public string EventOrganizer { get; set; }

        [Key]
        public Guid Id { get; set; }

    }
}