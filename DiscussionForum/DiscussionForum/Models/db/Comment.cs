using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.Models.db
{
    public partial class Comment
    {
        public int Did { get; set; }
        public int CommenNo { get; set; }
        [Required(ErrorMessage ="Please create comment")]
        [Display(Name = "Comment")]
        public string Decription { get; set; }
        public DateTime? ReplyDate { get; set; }

        [Display(Name ="User comment")]
        public string UserName { get; set; }
        public string UserIp { get; set; }
        public bool? IsShow { get; set; }

        public Discussion Discussion { get; set; }
    }
}
