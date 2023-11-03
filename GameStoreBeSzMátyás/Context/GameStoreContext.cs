using GameStoreBeSzMátyás.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBeSzMátyás.Context
{
    public class GameStoreContext:DbContext
    {
        User_entity user_Entity=new User_entity();
        VideoGame_entity videoGame_Entity=new VideoGame_entity();
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User_entity>().HasMany(e => e.VideoGame_Entities)
                                                .WithMany(e => e.User_Entities)
                                             .UsingEntity<uservideo>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=GameStoreContext;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<User_entity> User { get; set; }
        public DbSet<VideoGame_entity> VideoGame { get; set; }
        public DbSet<uservideo> UserVideo { get; set; }
        
    }
}
