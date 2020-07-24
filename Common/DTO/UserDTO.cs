

using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DTO
{
    [Table("AspNetUsers")]
    public class UserDTO
    {
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
