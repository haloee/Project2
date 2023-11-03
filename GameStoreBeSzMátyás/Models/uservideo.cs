using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GameStoreBeSzMátyás.Models
{
    public class uservideo
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public User_entity? User{get;set;}
        public VideoGame_entity? VideoGame { get;set;}

    }
    
}
