﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
<<<<<<< Updated upstream
        [StringLength(255)]
=======
>>>>>>> Stashed changes
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    }
}
