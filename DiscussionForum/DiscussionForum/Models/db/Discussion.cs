using System;
using System.Collections.Generic;

#nullable disable

namespace DiscussionForum.Models.db
{
    public partial class Discussion
    {
        public Discussion()
        {
            Comment = new HashSet<Comment>();
        }
        public int Did { get; set; }
        public string DiscussionTopic { get; set; }
        public string DiscussionDetails { get; set; }
        public int CategoryId { get; set; }
        public DateTime? RecordDate { get; set; }
        public int? ViewCount { get; set; }
        public int? ReplyCount { get; set; }
        public string UserName { get; set; }
        public string UserIp { get; set; }
        public bool? IsShow { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
