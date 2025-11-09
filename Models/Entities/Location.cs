
using System.Collections.Generic;

namespace CompleteExampleApp.Models.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Street { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public City? City { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}
