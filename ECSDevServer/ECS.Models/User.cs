using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECS.Models
{ 
    /// <summary>
    /// This model represents a given Account's personal information. 
    /// </summary>
    public class User
    {
        //Change user to UserProfile
        // The email a user submitted during registration
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // The first name a user submitted during registration
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        // The last name a user submitted during registration
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        // Navigation property of zipLocation class
        // A user can have multiple zipcode/addresses. Potentially a user has one or more houses or places of
        // residence to which we can send raffle prizes to.
        // MAke navigation a single ZipLocation
        public virtual ICollection<ZipLocation> ZipLocations { get; set; }
 
        // Unimplemented because of switch to web-api, but potential addition if change back to mvc
        // Navigation property of cookies class
        // A user can have many cookies
        //public virtual ICollection<Cookie> Cookies { get; set; }
    }
}
