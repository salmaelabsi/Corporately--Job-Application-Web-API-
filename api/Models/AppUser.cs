using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationSystem.api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
