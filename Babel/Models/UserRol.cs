namespace Babel.Models
{
    public class UserRol
    {
        public int UsuarioId { get; set; }
        public virtual User User { get; set; }
        //public User User { get; set; } 
        public int RoleId { get; set; }
        public Role Role { get; set; } 

    }
}
