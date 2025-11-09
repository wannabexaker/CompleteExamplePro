
using System.Collections.Generic;

namespace CompleteExampleApp.Models.Entities
{
    public class Tag
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<EventTag>? EventTags { get; set; }
    }
}
