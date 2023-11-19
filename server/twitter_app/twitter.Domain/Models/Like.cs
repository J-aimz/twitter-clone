using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class Like : BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser MyProperty { get; set; }
    }
}
