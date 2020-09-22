using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesManagement.api.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 5, ErrorMessage = "Enter a password between 5-17 characters")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}