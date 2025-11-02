using System.ComponentModel.DataAnnotations;
using PowerHouse.Constants;

namespace PowerHouse.Models
{
        public class User
    {

        public User()
        {
            Energy = AppConstants.DEFAULT_ENERGY;
            Name = string.Empty;
            PasswordHash = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set;}

        [Required]
        public  string Name { get; set;}
        [Required]
        public  string Email { get; set;}
        [Required]
        public  string PasswordHash { get; set;}

        public Int32 Energy { get; set;}


    
    }
}