using System;

namespace ExpensesManagement.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }    
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public int? Salary { get; set; }
    }
}