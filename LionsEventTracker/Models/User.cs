using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LionsEventTracker.Models
{
    public class User
    {
        //    internal object evnt;

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public byte[] salt { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public string EmailToken { get; set; }
        public bool IsVerified { get; set; }

        public List<EventUser> eventUsers { get; set; }
    }
}
