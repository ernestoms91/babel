using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Babel.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool active { get; set; } = true;
        public string Nid { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get;set; } = DateTime.Now;
        // M a M
        public List<UserRol> UserRoles { get; set; } = new List<UserRol>();

    }
}
