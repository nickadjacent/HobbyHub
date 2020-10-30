using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models
{
    public class UserHobby
    {
        [Key]
        public int UserHobbyId { get; set; }

        public int UserId { get; set; }
        public int HobbyId { get; set; }

        public User User { get; set; }
        public Hobby Hobby { get; set; }



    }
}