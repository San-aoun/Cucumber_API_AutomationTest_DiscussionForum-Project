using System;
using System.Collections.Generic;

#nullable disable

namespace DiscussionForum.Models.db
{
    public partial class Category
    {
        public Category()
        {
            Discussion = new HashSet<Discussion>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Discussion> Discussion { get; set; }
    }
}
