using DataAccess.Models.Enums;

namespace DataAccess.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public bool RoleId { get; set; }
    }
}
