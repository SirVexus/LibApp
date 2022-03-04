<<<<<<< Updated upstream
﻿using System;
=======
﻿using LibApp.Models;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Dtos
{
    public class CustomerDto
    {
<<<<<<< Updated upstream
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        [Required]
        public byte MembershipTypeId { get; set; }
=======
        public string Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
>>>>>>> Stashed changes
        public DateTime? Birthdate { get; set; }
    }
}
