using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class UserFollowing : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public Guid FollowingId { get; set; }
    }
}
