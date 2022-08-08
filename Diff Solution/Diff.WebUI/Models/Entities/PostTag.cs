using Diff.WebUI.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Diff.WebUI.Models.Entities
{
    public class PostTag : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<BlogPostTag> TagCloud{ get; set; }
    }

    public class BlogPostTag
    {
        public int BlogPostId { get; set; }
        public virtual Blogpost Blogpost { get; set; }
        public int  PostTagId { get; set; }
        public virtual PostTag PostTag { get; set; }

    }
}
