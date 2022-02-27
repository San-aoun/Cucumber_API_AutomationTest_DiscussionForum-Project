using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Please create the question")]
        [Display(Name ="Create question")]
        [StringLength(100,MinimumLength =10,ErrorMessage = "Please create question with wording 10-100")]
        public string DiscussionTopic { get; set; }

        [Required(ErrorMessage = "Please create the detail infomation")]
        [Display(Name = "Details")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Please create details with wording 10-255")]
        public string DiscussionDetails { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public DateTime? RecordDate { get; set; }

        public int? ViewCount { get; set; }

        public int? ReplyCount { get; set; }

        //[Required(ErrorMessage = "Please create name")]
        [Display(Name = "User created")]
        public string UserName { get; set; }

        public string UserIp { get; set; }

        public bool? IsShow { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
