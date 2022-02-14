using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models.db;

namespace DiscussionForum.ViewModel
{
    public class TopicCommentVeiwModel
    {
        public IQueryable<Comment> CommentsLists { get; set; }
        public Discussion Discussion { get; set; }
        
    }
}
