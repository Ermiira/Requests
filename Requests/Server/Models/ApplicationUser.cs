﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData] 
        public string LastName { get; set; }

        [PersonalData] 
        public DateTime Birthdate { get; set; }
    }
}
