using System;
using System.Collections.Generic;

namespace Task_1.Models
{
    public partial class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? Dob { get; set; }
        public string? Gender { get; set; }
    }
}
