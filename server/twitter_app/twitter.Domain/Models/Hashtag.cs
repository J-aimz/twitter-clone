using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class Hashtag : BaseEntity
    {
        public string Text { get; set; }
        public long PostCount { get; set; }
    }
}
