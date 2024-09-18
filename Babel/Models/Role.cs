using System.ComponentModel.DataAnnotations;

namespace Babel.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        
        // M a M
        public List<UserRol> UserRoles { get; set; } = new List<UserRol>();

    }
}
