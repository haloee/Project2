using System.ComponentModel.DataAnnotations;
using GameStoreBeSzMátyás.Models;

namespace GameStoreBeSzMátyás.Models
{
    public class VideoGame_entity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required,StringLength(255)]
        public string Description { get; set; }
        [Required]
        public  Types Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required,Range(1,5)]
        public int Rating { get; set; }
        public List<User_entity> User_Entities { get; } = new();
       

    }
   public enum Types
    {
        Akció,
        Kaland,
        Coop,
        Oktató,
        Túlélő
    }
}
