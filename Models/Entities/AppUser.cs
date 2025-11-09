
using System;
using System.Collections.Generic;

namespace CompleteExampleApp.Models.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Email { get; set; } = string.Empty;

        public Organizer? Organizer { get; set; }
        public ICollection<EventUser>? EventUsers { get; set; }
    }
}
