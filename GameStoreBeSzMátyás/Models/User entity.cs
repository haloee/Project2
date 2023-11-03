using System.ComponentModel.DataAnnotations;
using GameStoreBeSzMátyás.Models;
namespace GameStoreBeSzMátyás.Models
{
    public class User_entity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(255)]
        public string PasswordHash { get; set; }
        public List<VideoGame_entity> VideoGame_Entities { get; } = new();
    }
}
