<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> Stashed changes
using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Customer : IdentityUser
    {
<<<<<<< Updated upstream
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide customer's name")]
=======
        [Required(ErrorMessage = "Please enter customer's name")]
>>>>>>> Stashed changes
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
<<<<<<< Updated upstream
        [Required(ErrorMessage = "Please provide Membership Type")]
=======
>>>>>>> Stashed changes
        public byte MembershipTypeId { get; set; }
        [Display(Name="Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
<<<<<<< Updated upstream
=======
        
>>>>>>> Stashed changes
    }
}