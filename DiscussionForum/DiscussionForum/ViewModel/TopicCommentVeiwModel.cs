using DiscussionForum.Models.db;
using System.Linq;

namespace DiscussionForum.ViewModel
{
    public class TopicCommentVeiwModel
    {
        public IQueryable<Comment> CommentsLists { get; set; }
        public Discussion Discussion { get; set; }
        
    }
}
