using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class AppUser : IdentityUser<Guid> 
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public bool Verified { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }

        [MaxLength(240)]
        public string Bio { get; set; }

    }
}
