using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }


        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public int UserId { get; set; }



        // Navigation Properties


        public User SubmittedBy { get; set; }

        public List<UserHobby> UserHobbies { get; set; }


    }
}