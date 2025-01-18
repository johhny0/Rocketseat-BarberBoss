using Domain.Enums;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = Roles.TEAM_MEMBER;

        public List<Billing> Billings { get; set; } = [];
    }
}
