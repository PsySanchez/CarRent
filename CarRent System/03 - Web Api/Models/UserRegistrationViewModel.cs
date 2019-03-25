using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent
{
    public class UserRegistrationViewModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [StringLength(12, MinimumLength = 6)]
        public string password { get; set; }

        public string email { get; set; }

        [StringLength(15, MinimumLength = 9)]
        public string telephone { get; set; }

        public DateTime? dateOfBirth { get; set; }
    }
}
