using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class PostMention : BaseEntity
    {
        public Guid PostId { get; set; }
        public string Mention { get; set; }
    }
}
