
namespace CompleteExampleApp.Models.Entities
{
    public class Organizer
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
        public AppUser? AppUser { get; set; }
    }
}
