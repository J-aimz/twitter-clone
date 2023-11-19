using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class Image : BaseEntity
    {
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
    }
}
