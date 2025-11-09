
namespace CompleteExampleApp.Models.Entities
{
    public class EventTag
    {
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public string TagName { get; set; } = string.Empty;
        public Tag? Tag { get; set; }
    }
}
