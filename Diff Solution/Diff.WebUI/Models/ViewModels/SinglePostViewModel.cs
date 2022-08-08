using Diff.WebUI.Models.Entities;
using System.Collections.Generic;

namespace Diff.WebUI.Models.ViewModels
{
    public class SinglePostViewModel
    {
        public Blogpost Post { get; set; }
        public IEnumerable<Blogpost> RelatedPosts { get; set; }
    }
}
