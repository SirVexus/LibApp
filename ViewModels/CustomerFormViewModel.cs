using LibApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< Updated upstream
using System.Linq;
using System.Threading.Tasks;
=======
>>>>>>> Stashed changes

namespace LibApp.ViewModels
{
    public class CustomerFormViewModel
    {
<<<<<<< Updated upstream
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please provide Membership Type")]
=======
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter customer's email")]
        [EmailAddress]
        public string Email { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Membership Type is required")]
>>>>>>> Stashed changes
        public byte? MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
<<<<<<< Updated upstream
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

=======

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
>>>>>>> Stashed changes
        public string Title
        {
            get
            {
<<<<<<< Updated upstream
                return Id != 0 ? "Edit Customer" : "New Customer";
=======
                return Id != "" ? "Edit Customer" : "New Customer";
>>>>>>> Stashed changes
            }
        }

        public CustomerFormViewModel()
        {
<<<<<<< Updated upstream
            Id = 0;
=======
            Id = "";
>>>>>>> Stashed changes
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
<<<<<<< Updated upstream
            MembershipTypeId = customer.MembershipTypeId;
            HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
=======
            Email = customer.Email;
            HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
            MembershipTypeId = customer.MembershipTypeId;
>>>>>>> Stashed changes
            Birthdate = customer.Birthdate;
        }
    }
}
