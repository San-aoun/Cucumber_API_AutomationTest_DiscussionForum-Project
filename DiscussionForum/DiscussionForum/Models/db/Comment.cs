using System;
using System.Collections.Generic;

namespace DiscussionForum.Models.db
{
    public partial class Comment
    {
        public int Did { get; set; }
        public int CommenNo { get; set; }
        public string Decription { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string UserName { get; set; }
        public string UserIp { get; set; }
        public bool? IsShow { get; set; }

        public Discussion Discussion { get; set; }
    }
}
