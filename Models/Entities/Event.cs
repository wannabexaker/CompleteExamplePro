
using System;
using System.Collections.Generic;

namespace CompleteExampleApp.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? DatePlanned { get; set; } = DateTime.UtcNow;

        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? MaxParticipants { get; set; }
        public int? MinAge { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public int? OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }
        public ICollection<EventUser>? EventUsers { get; set; }
        public ICollection<EventTag>? EventTags { get; set; }
    }
}
