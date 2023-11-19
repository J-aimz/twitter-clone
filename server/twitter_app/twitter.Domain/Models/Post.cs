using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Models
{
    public class Post : BaseEntity
    {
        public Guid AuthorId { get; set; }

        [MaxLength(240)]
        public string Message { get; set; }
        public ICollection<Image>? Images { get; set; }
        public int? RepostsCount { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Hashtag>? Hashtags { get; set; }
        public ICollection<Like> Likes { get; set; }

    }
}
