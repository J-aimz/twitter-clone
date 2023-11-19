using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
       
    }
}
