using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationSystem.api.Models
{
    [Table("Applications")]
    public class Application
    {
        public string AppUserId { get; set; }
        public int JobId { get; set; }

        public AppUser AppUser { get; set; }
        public Job Job { get; set; }
    }
}