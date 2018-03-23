using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECS.Models
{
    /// <summary>
    /// This model represents the address information associated with a given user.  It does not contain any type of
    /// validation logic, it simply stores information given during registration.
    /// </summary>
    public class ZipLocation
    {
        // TODO: @Kris might need generated ID?
        [Key]
        [Required]
        public int ZipCodeId { get; set; }
        // The area code given during registration
        // ZipCode should not be in ZipLocation
        [Required]
        //[Key, Column(Order = 1)] 
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Zipcode must be 5-10 characters")]
        public string ZipCode { get; set; }

        // The street number and street given during registration
        //[Key, Column(Order = 0)]
        [Required]
        public string Address { get; set; }

        // The city given during registration
        [Required]
        public string City { get; set; }

        // The state given during registration
        [Required]
        public string State { get; set; }

        // The latitude of a given location.  This is optional because our system only refers to the SoCAL area
        // Thus there should not be any duplicate combinations of cities streets and zipcodes.
        public int Latitude { get; set; }

        // The longitude of a given location.  This is optional because our system only refers to the SoCAL area
        // Thus there should not be any duplicate combinations of cities streets and zipcodes.
        public int Longitude { get; set; }

        //Foreign Key of Email
        //[Required]
        //[Key, Column(Order = 0)]
        //public string Email { get; set; }

        // TODO: @Kris so we don't need this?
        // Navigation property of Email
        // DO not need this 
        public ICollection<User> Users { get; set; }

        public ZipLocation()
        {
            this.Users = new List<User>();
        }
    }
}
