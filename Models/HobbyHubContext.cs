using Microsoft.EntityFrameworkCore;

namespace HobbyHub.Models
{
    public class HobbyHubContext : DbContext
    {
        // constructor
        public HobbyHubContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<UserHobby> UserHobbies { get; set; }

    }
}
