using DiscussionForum.Models.db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscussionForum.Service
{
    public class CommentService
    {
        private readonly discussionForumDBContext _db;

        public CommentService(discussionForumDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByDid(int id)
        {
            IQueryable<Comment> cs = _db.Comments
                .OrderBy(c => c.CommenNo)
                .Where(i => i.IsShow == true)
                .Where(j => j.Did == id);

            return await cs.ToListAsync();  
        }
    }
}
